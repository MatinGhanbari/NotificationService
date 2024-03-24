using System.Security.Authentication;
using Core.Events.EventHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Core.Events.EventBus.RabbitMQ;

public sealed class RabbitMQBus(IServiceScopeFactory serviceScopeFactory, IOptions<RabbitMQConfig> rabbitMqConfigOptions) : IEventBus
{
    private readonly Dictionary<string, List<Type>> _handlers = new();
    private readonly List<Type> _eventTypes = new();
    private readonly RabbitMQConfig rabbitMqConfig = rabbitMqConfigOptions.Value;

    public void Publish<T>(T @event) where T : BaseEvent
    {
        var factory = new ConnectionFactory
        {
            HostName = rabbitMqConfig.Host,
            Port = rabbitMqConfig.Port,
            UserName = rabbitMqConfig.Username,
            Password = rabbitMqConfig.Password
        };

        using var connection = factory.CreateConnection();
        var model = connection.CreateModel();
        var properties = model.CreateBasicProperties();
        properties.Persistent = true;
        using var channel = connection.CreateModel();
        var eventName = @event.GetType().Name;
        channel.QueueDeclare(eventName, true, false, false, null);
        var message = JsonConvert.SerializeObject(@event, Formatting.Indented);
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish("", eventName, true, properties, body);
    }

    public void Subscribe<T, TH>() where T : BaseEvent where TH : IEventHandler<T>
    {
        var eventName = typeof(T).Name;
        var handlerType = typeof(TH);

        if (!_eventTypes.Contains(typeof(T)))
            _eventTypes.Add(typeof(T));

        if (!_handlers.ContainsKey(eventName))
            _handlers.Add(eventName, new List<Type>());

        if (_handlers[eventName].Any(s => s == handlerType))
            throw new ArgumentException($"Handler Type {handlerType.Name} already is registered for '{eventName}'", nameof(handlerType));

        _handlers[eventName].Add(handlerType);
        StartBasicConsume<T>();
    }

    private void StartBasicConsume<T>() where T : BaseEvent
    {
        var factory = new ConnectionFactory
        {
            DispatchConsumersAsync = true,
            HostName = rabbitMqConfig.Host,
            Port = rabbitMqConfig.Port,
            UserName = rabbitMqConfig.Username,
            Password = rabbitMqConfig.Password,
            AmqpUriSslProtocols = SslProtocols.None
        };

        var connection = default(IConnection);
        var isConnected = false;

        while (!isConnected)
        {
            try
            {
                connection = factory.CreateConnection();
                isConnected = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Thread.Sleep(1000);
            }
        }

        var channel = connection?.CreateModel();

        var eventName = typeof(T).Name;
        channel.QueueDeclare(eventName, true, false, false, null);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += Consumer_Received;
        channel.BasicConsume(eventName, true, consumer);
    }

    private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
    {
        var eventName = e.RoutingKey;
        var message = Encoding.UTF8.GetString(e.Body.ToArray());
        try
        {
            await ProcessEvent(eventName, message).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private async Task ProcessEvent(string eventName, string message)
    {
        if (_handlers.TryGetValue(eventName, out var subscriptions))
        {
            using var scope = serviceScopeFactory.CreateScope();
            foreach (var subscription in subscriptions)
            {
                var handler = scope.ServiceProvider.GetService(subscription);
                if (handler == null) continue;
                var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                var @event = JsonConvert.DeserializeObject(message, eventType);
                var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                await (Task)concreteType.GetMethod("Handle")?.Invoke(handler, new object[] { @event });
            }
        }
    }
}