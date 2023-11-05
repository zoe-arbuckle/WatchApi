using Microsoft.AspNetCore.Http.HttpResults;
using WatchApi.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Watch> TypesOfWatches = new List<Watch>();
TypesOfWatches.Add(new Watch()
{
    Id = 1,
    Name = "Rolex",
    UnitPrice = 100,
    UnitsForDiscount = 3,
    DiscountMarkdown = 200
});
TypesOfWatches.Add(new Watch()
{
    Id = 2,
    Name = "Michael Kors",
    UnitPrice = 80,
    UnitsForDiscount = 2,
    DiscountMarkdown = 120
});
TypesOfWatches.Add(new Watch()
{
    Id = 3,
    Name = "Swatch",
    UnitPrice = 50,
});
TypesOfWatches.Add(new Watch()
{
    Id = 4,
    Name = "Casio",
    UnitPrice = 30,
});


app.MapPost("/checkout", (string[] ids) =>
{
    int totalPrice = 0;
    // dictionary key = watch id, value = number of watches in checkout
    Dictionary<int, int> WatchCheckoutCount = new Dictionary<int, int>();
    foreach (string stringId in ids)
    {
        int id = 0;
        if (!Int32.TryParse(stringId, out id))
        {
            // invalid input, respond with error
            throw new ArgumentException();
        }

        if(WatchCheckoutCount.ContainsKey(id)){
            WatchCheckoutCount[id] += 1;
        } else {
            WatchCheckoutCount[id] = 1;
        }
    }

    totalPrice = CalculateTotal(WatchCheckoutCount);

    return new { Price = totalPrice };

});

int CalculateTotal(Dictionary<int, int> watchCheckoutCount)
{
    int total = 0;
    foreach(var item in watchCheckoutCount){
        Watch? w = TypesOfWatches.Find(watch => watch.Id == item.Key);
        if(w == null){
            throw new ArgumentNullException();
        }

        total += (item.Value/w.UnitsForDiscount) * w.DiscountMarkdown
            + (item.Value%w.UnitsForDiscount) * w.UnitPrice;
    }

    return total;
}

app.Run();
