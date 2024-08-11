using System.Reflection;

using MinimalAPIs_Example.DTOs;
using MinimalAPIs_Example.Endpoints;
using MinimalAPIs_Example.Mapping;
using MinimalAPIs_Example.Repositories;

var builder = WebApplication.CreateBuilder(args);



// For Minimal APIs, we don't need to add controllers
//builder.Services.AddControllers();

builder.Services.AddSingleton<Orders>();

builder.Services.AddSingleton<OrderMapper>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.Converters.Add(new DataTypeJsonConverter());
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

// For Minimal APIs, we don't need to map controllers
//app.MapControllers(); 

// Add the route group builder for the endpoints.  
app.MapOrders();

app.Run();
