using CashFlow.Api.Filters;
using CashFlow.Application;
using CashFlow.Infrastrucutre;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DocsCors", policy =>
    {
        policy
            .WithOrigins("http://127.0.0.1:4000", "http://localhost:4000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "API v1");
    });

    app.MapScalarApiReference();
}
else
{
    app.UseHttpsRedirection();
}

app.UseCors("DocsCors");

app.UseAuthorization();

app.MapControllers();

app.Run();