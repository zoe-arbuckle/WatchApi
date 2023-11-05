using System.Globalization;
using WatchApi;
using WatchApi.Controller;

namespace WatchApiTest;
public class WatchApiTest
{
    [Fact]
    public void EmptyCheckoutItems()
    {
        PriceCalculator calculator = new PriceCalculator();
        int result = calculator.CalculateTotal(new string[0]);
        Assert.Equal(0, result);
    }

    [Fact]
    public void OneOfEach()
    {
        string[] ids = new string[]{"001", "002", "003", "004"};
        PriceCalculator calculator = new PriceCalculator();
        int result = calculator.CalculateTotal(ids);

        Assert.Equal(260, result);
    }

    [Fact]
    public void UnknownInput(){
        string[] ids = new string[]{"006"};
        PriceCalculator calculator = new PriceCalculator();
        
        Assert.Throws<ArgumentException>(() => calculator.CalculateTotal(ids));
    }

    [Fact]
    public void InvalidInput()
    {
        string[] ids = new string[]{"Not an integer"};
        PriceCalculator calculator = new PriceCalculator();

        Assert.Throws<ArgumentException>(() => calculator.CalculateTotal(ids));
    }

    [Fact]
    public void DiscountTest()
    {
        string[] ids = new string[]{"001", "001", "001"};
        PriceCalculator calculator = new PriceCalculator();

        Assert.Equal(200, calculator.CalculateTotal(ids));
    }
}