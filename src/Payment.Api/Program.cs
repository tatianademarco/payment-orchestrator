using Payment.Application.Payments.Commands;
using Payment.Application.Abstractions.Persistence;
using Payment.Application.Abstractions.Messaging;
using Payment.Infrastructure.Persistence;
using Payment.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CreatePaymentHandler>();

builder.Services.AddScoped<IPaymentRepository, InMemoryPaymentRepository>();

builder.Services.AddScoped<IPaymentPublisher, FakePaymentPublisher>();

builder.Services.AddScoped<CreatePaymentHandler>();

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
