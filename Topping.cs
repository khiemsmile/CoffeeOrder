using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrder
{
    public abstract class ToppingDecorator : ICoffee
    {
        protected ICoffee coffee;

        public ToppingDecorator(ICoffee coffee)
        {
            this.coffee = coffee;
        }

        public abstract string GetDescription();
        public abstract int GetCost();
    }

    public class Milk : ToppingDecorator
    {
        public Milk(ICoffee coffee) : base(coffee) { }
        public override string GetDescription() => coffee.GetDescription() + ", Milk";
        public override int GetCost() => coffee.GetCost() + 5000;
    }

    public class WhippedCream : ToppingDecorator
    {
        public WhippedCream(ICoffee coffee) : base(coffee) { }
        public override string GetDescription() => coffee.GetDescription() + ", Whipped Cream";
        public override int GetCost() => coffee.GetCost() + 8000;
    }

    public class Caramel : ToppingDecorator
    {
        public Caramel(ICoffee coffee) : base(coffee) { }
        public override string GetDescription() => coffee.GetDescription() + ", Caramel";
        public override int GetCost() => coffee.GetCost() + 10000;
    }
}
