using Application.Instructions.Interfaces;
using Application.Instructions.Services;
using Application.Notifications.Interfaces;
using Application.Notifications.Services;
using Domain.Instructions.Interfaces;
using Domain.Notifications.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.UnitOfWorks;
using Infrastructure.Scheduler;
using Presentation.Instructions.Commands;
using Quartz;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var userDbConnectionString = builder.Configuration.GetConnectionString("UserDb");
var instructionDbConnectionString = builder.Configuration.GetConnectionString("InstructionDb");
var notificationDbConnectionString = builder.Configuration.GetConnectionString("NotificationDb");
builder.Services.AddPersistence(userDbConnectionString, instructionDbConnectionString, notificationDbConnectionString );

builder.Services.AddScoped<IInstructionUoW, InstructionUoW>();
builder.Services.AddScoped<INotificationUoW, NotificationUoW>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateInstructionCommand).Assembly));

builder.Services.AddScoped<IInstructionService, InstructionService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<INotificationPublicAPI, NotificationPublicAPI>();

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

builder.Services.AddSingleton<Domain.Core.Interfaces.IScheduler, Scheduler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // XML dosyasýnýn yolunu belirle
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.WebHost.UseUrls("http://0.0.0.0:5000");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
