using ConsumerApplication.Notification.Events;
using ConsumerApplication.Notification.Handler;
using Core.Events.EventBus;
using Core.Events.EventBus.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrapper;

public static class EventBusServices
{
    public static IServiceCollection RegisterEventBusServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMQConfig>(configuration.GetSection(nameof(RabbitMQConfig)));
        services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
        {
            var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            return new RabbitMQBus(scopeFactory, configuration.GetValue<RabbitMQConfig>(nameof(RabbitMQConfig))!);
        });

        return services;
    }

    public static void SubscribeEvents(this IServiceProvider services)
    {
        var eventBus = services.GetRequiredService<IEventBus>();

        eventBus.Subscribe<NotificationEvent, NotificationEventHandler>();
    }
}