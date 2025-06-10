using Hangfire;
using HangFire.Dtos;
using Hangfire.MemoryStorage;
using HangFire.Notifiers.Email;
using HangFire.UseCase;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.Configure<MailOptions>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<ISendEmail, SendEmail>();
builder.Services.AddScoped<AddOrder>();
builder.Services.AddHangfire(config => config.UseMemoryStorage());
builder.Services.AddHangfireServer();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.MapGet("/", () => "healthy");

app.MapPost("/add-order", async ([FromBody]OrderDto order, AddOrder addOrder
    ,ILogger<Program> logger) =>
    {
        await addOrder.Execute(order);
        logger.LogInformation("servicio de add-order ejecutado correctamente");
        return Results.Ok("Order processed successfully");
    })
    .WithName("AddOrder");

app.Run();

