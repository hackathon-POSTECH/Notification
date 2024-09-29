using MassTransit;
using NOTIFICATION.APPLICATION;
using NOTIFICATION.APPLICATION.Abstractions.Http;
using NOTIFICATION.APPLICATION.DTOs;
using NOTIFICATION.APPLICATION.Gateways;
using NOTIFICATION.APPLICATION.UseCases;
using NOTIFICATION.APPLICATION.UseCases.SendAppointmentNotificationToDoctor;
using NOTIFICATION.APPLICATION.UseCases.SendAppointmentNotificationToPatient;
using NOTIFICATION.DOMAIN.Factories;
using NOTIFICATION.INFRA.Adapters.Http;
using NOTIFICATION.INFRA.Factories;
using NOTIFICATION.INFRA.RabbitMQ.Consumers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<INotificationFactory, NotificationFactory>();
builder.Services.AddScoped<SendAppointmentNotificationToPatient>();
builder.Services.AddScoped<SendAppointmentNotificationToDoctor>();
builder.Services.AddScoped<IPatientGateway, PatientGateway>();
builder.Services.AddScoped<IDoctorGateway, DoctorGateway>();
builder.Services.AddScoped<FindDoctorById>();
builder.Services.AddScoped<FindPatientById>();
builder.Services.AddHttpClient<IHttpClientService, HttpClientService>();

var rabbitMqSettings = builder.Configuration.GetSection("RabbitMQ");

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AppointmentNotificationConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username(rabbitMqSettings["Username"]);
            h.Password(rabbitMqSettings["Password"]);
        });

        cfg.Message<DoctorRequestDTO>(x => x.SetEntityName("get-doctor"));
        cfg.Message<DoctorResponseDTO>(x => x.SetEntityName("get-doctor"));
        cfg.Message<PatientRequestDTO>(x => x.SetEntityName("get-doctor"));
        cfg.Message<PatientResponseDTO>(x => x.SetEntityName("get-doctor"));

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
