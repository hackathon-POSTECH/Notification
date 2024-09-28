using MassTransit;
using NOTIFICATION.APPLICATION;
using NOTIFICATION.INFRA.RabbitMQ.Consumers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<INotificationService, NotificationService>();

var rabbitMqSettings = builder.Configuration.GetSection("RabbitMQ");

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AppointmentNotificationConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            // Get of configuration
            h.Username(rabbitMqSettings["Username"]);
            h.Password(rabbitMqSettings["Password"]);
        });

        cfg.ReceiveEndpoint("notification_queue",
            e => { e.ConfigureConsumer<AppointmentNotificationConsumer>(context); });
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
