using ConsumerApplication.Notification.Events;
using ConsumerApplication.Notification.Handler;
using Core.Events.EventHandler;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrapper;

public static class NotificationServices
{
    public static IServiceCollection AddGrpcServices(this IServiceCollection services)
    {
        services.AddGrpc(cfg => cfg.EnableDetailedErrors = true);
        return services;
    }

    public static IServiceCollection AddNotificationService(this IServiceCollection services)
    {
        services.AddSingleton<ConsumerApplication.GrpcServices.NotificationService>();
        return services;
    }

    public static IServiceCollection AddCorsService(this IServiceCollection services)
    {
        services.AddCors(cfg =>
        {
            cfg.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return services;
    }

    public static IServiceCollection RegisterEventHandlers(this IServiceCollection services)
    {
        services.AddTransient<NotificationEventHandler>();
        services.AddTransient<IEventHandler<NotificationEvent>, NotificationEventHandler>();

        return services;
    }
}