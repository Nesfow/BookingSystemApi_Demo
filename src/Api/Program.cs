using BookingSystemApi.Api.Endpoints;
using BookingSystemApi.Application;
using BookingSystemApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.MapEventEndpoints();
app.MapLocationEndpoints();

app.Run();
