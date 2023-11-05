var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/checkout", (string[] ids) => {
    
});

app.Run();
