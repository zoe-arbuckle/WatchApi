namespace WatchApi.Models;

public class Watch{
    public required int Id {get; set;}
    public string? Name {get; set;}
    public required int UnitPrice {get; set;}
    public int UnitsForDiscount {get; set;}
    public int DiscountMarkdown {get; set;}
}