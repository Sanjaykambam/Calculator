using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CalculatorApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICalculator, Calculator>();

var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapGet("/api/calc", (string op, double a, double b, ICalculator calc) =>
{
    return Results.Ok(op.ToLowerInvariant() switch
    {
        "add" or "+" => calc.Add(a, b),
        "sub" or "-" => calc.Subtract(a, b),
        "mul" or "*" => calc.Multiply(a, b),
        "div" or "/" => calc.Divide(a, b),
        _ => throw new InvalidOperationException("Unknown operation")
    });
});
app.Run();
