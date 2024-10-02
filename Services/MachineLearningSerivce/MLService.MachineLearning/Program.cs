using MassTransit;
using Microsoft.EntityFrameworkCore;
using MLService.Extensions;
using MLService.Infrastructure;
using MLService.MachineLearning.BAL.Services;
using MLService.MachineLearning.BAL.Services.Impl;
using MLService.MachineLearning.Consumers;
using MLService.MachineLearning.DAL.Data;
using System.Reflection;
using MLService.Infrastructure.Models.Settings;
using MLService.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.AddCustomConfigurations();

#region DI
builder.Services.AddScoped<ILearnService, LearnService>();
#endregion

builder.Services.AddMassTransit(config =>
{
    config.AddConsumers(Assembly.GetExecutingAssembly());

   

    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(AppSettings.MassTransit.Host, 5672, "/", h =>
        {
            h.Username(AppSettings.RabbitMq.UserName);
            h.Password(AppSettings.RabbitMq.Password);
        });
        cfg.ConfigureEndpoints(context);
        
        /*cfg.ReceiveEndpoint(AppSettings.MLService.Endpoints.Test, e =>
        {
            e.PrefetchCount = 20;
            e.UseMessageRetry(r => r.Interval(2, 100));
            e.ConfigureConsumer<CreateMachineConsumer>(context);
        });*/
    });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Machine Learn Service",
        Version = typeof(Program).Assembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion
    });
}
);

builder.Services.AddDbContext<MachineLearnDbContext>(x =>
    {
        if (AppSettings.MLService.DbType == "MsSql")
        {
            x.UseSqlServer(AppSettings.MLService.ConnectionString, y => y.MigrationsAssembly("MLService.MachineLearning.Migrations"));
        }
        else
            throw new Exception(Constants.UndefineDbException);
    }
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
