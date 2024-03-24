using Bootstrapper;
using ConsumerApplication.GrpcServices;

var builder = WebApplication.CreateBuilder(args);

// Add event bus services
builder.Services.RegisterEventBusServices(builder.Configuration);

// Add notification services
builder.Services.AddCorsService()
                .AddGrpcServices()
                .RegisterEventHandlers()
                .AddNotificationService();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
    //app.UseHttpsRedirection();
}

app.UseCors("AllowAll");

app.UseGrpcWeb();
app.MapGrpcService<NotificationService>().EnableGrpcWeb();

app.Services.SubscribeEvents();

app.Run();