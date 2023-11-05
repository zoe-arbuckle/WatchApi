using Microsoft.AspNetCore.Http.HttpResults;
using WatchApi.Controller;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/checkout", (string[] ids) =>
{
    PriceCalculator calculator = new PriceCalculator();
    try{
        int totalPrice = calculator.CalculateTotal(ids);
        return TypedResults.Ok(new {Price = totalPrice});
    } catch (ArgumentException){
        return Results.BadRequest();
    }
    
});

app.Run();
