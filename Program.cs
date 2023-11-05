using Microsoft.AspNetCore.Http.HttpResults;
using WatchApi.Controller;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/checkout", (string[] ids) =>
{
    PriceCalculator calculator = new PriceCalculator();
    return new { Price = calculator.CalculateTotal(ids) };
});



app.Run();
