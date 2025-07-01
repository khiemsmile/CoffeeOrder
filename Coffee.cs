using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrder
{
    public interface ICoffee
    {
        string GetDescription();
        int GetCost();
    }

    public class Latte : ICoffee
    {
        public string GetDescription() => "Latte";
        public int GetCost() => 35000;
    }

    public class Espresso : ICoffee
    {
        public string GetDescription() => "Espresso";
        public int GetCost() => 25000;
    }

    public class Mocha : ICoffee
    {
        public string GetDescription() => "Mocha";
        public int GetCost() => 45000;
    }

    public class Cappuccino : ICoffee
    {
        public string GetDescription() => "Cappuccino";
        public int GetCost() => 40000;
    }
    public class Americano : ICoffee
    {
        public string GetDescription() => "Americano";
        public int GetCost() => 30000;
    }


    public class CoffeeFactory
    {
        private Dictionary<string, ICoffee> _cache = new();

        public ICoffee GetCoffee(string type)
        {
            if (!_cache.ContainsKey(type))
            {
                _cache[type] = type switch
                {
                    "Latte" => new Latte(),
                    "Espresso" => new Espresso(),
                    "Mocha" => new Mocha(),
                    "Americano" => new Americano(),
                    "Cappuccino" => new Cappuccino(),
                    _ => throw new Exception("Unknown type")
                };
            }
            return _cache[type];
        }
    }

}
