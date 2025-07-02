// See https://aka.ms/new-console-template for more information
using CoffeeOrder;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // để đảm bảo toàn bộ output đều dùng UTF-8

        var menu = new MenuProxy();
        menu.GetMenu("Thân thiết");
        menu.GetMenu("Mới");

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