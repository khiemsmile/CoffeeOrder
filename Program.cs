// See https://aka.ms/new-console-template for more information
using CoffeeOrder;

public class Program
{
    public static void Main()
    {
        var factory = new CoffeeFactory();
        var latte = factory.GetCoffee("Latte");
        var latteWithToppings = new WhippedCream(new Milk(latte));

        var mocha = factory.GetCoffee("Mocha");
        var mochaWithTopping = new Caramel(mocha);

        var items = new List<ICoffee> { latteWithToppings, mochaWithTopping };

        var facade = new OrderFacade();
        facade.ProcessOrder(items, "Thân thiết");
    }
}