
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrder
{

    public interface IMenu
    {
        List<string> GetMenu(string customerType);
    }
    public class RealMenu : IMenu
    {
        public List<string> GetMenu(string customerType)
        {
            var menu = new List<string> { "Espresso", "Americano", "Latte", "Milk", "Sugar", "Whipped Cream" };
            if (customerType == "Thân thiết")
                menu.AddRange(new[] { "Cappuccino", "Mocha", "Caramel", "Vanilla" });
            return menu;
        }
    }

    public class MenuProxy : IMenu
    {
        private RealMenu _realMenu = new();
        public List<string> GetMenu(string customerType)
        {
            Console.WriteLine($"[LOG] {customerType} accessed menu at {DateTime.Now}");
            return _realMenu.GetMenu(customerType);
        }
    }

    public class OrderFacade
    {
        public void ProcessOrder(List<ICoffee> items, string customerType)
        {
            int total = items.Sum(x => x.GetCost());
            if (customerType == "Thân thiết")
                total = (int)(total * 0.9);

            Console.WriteLine("Chi tiết đơn hàng:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.GetDescription()} - {item.GetCost():N0} VND");
            }
            Console.WriteLine($"Tổng tiền: {total:N0} VND");
            Console.WriteLine("Thanh toán thành công!");
        }
    }
}
