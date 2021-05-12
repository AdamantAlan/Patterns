using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    abstract class Pizza
    {
        public string Name { get; protected set; }
        public Pizza(string name)
        {
            Name = name;
        }
        internal abstract int GetCost();
    }
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza()
            : base("Болгарская пицца")
        { }
        internal override int GetCost()
        {
            return 8;
        }
    }
    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца")
        { }
        internal override int GetCost()
        {
            return 10;
        }
    }
    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.pizza = pizza;
        }
    }
    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p)
            : base(p.Name + ", с томатами", p)
        { }

        internal override int GetCost()
        {
            return pizza.GetCost() + 3;
        }
    }
}
