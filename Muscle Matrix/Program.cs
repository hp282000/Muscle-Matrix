using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Muscle_Matrix.Configuration;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddControllers().AddFluentValidation(x=> x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.ManualAuthentication(builder.Configuration);
//JwtAuthentication.ManualAuthentication(builder.Configuration);
//its static method so why it is not call like JwtAuthentication.ManualAuthentication(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Manual Configuration
builder.Services.AddSqlServer(builder.Configuration);
builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

