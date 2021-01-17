using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
    public class Order : AModel {
        public Store Store { get; set; }
        public User User { get; set; }
        public long StoreEntityId { get; set; }
        public long UserEntityId { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public double Price { get; set; }

        public Order() {
            Pizzas = new List<Pizza>();
        }

        public void MakePizza(string Crust, string Size, string Topping1, string Topping2, string Topping3, string Topping4, string Topping5) {
            Pizza p = new Pizza(Crust, Size, Topping1, Topping2, Topping3, Topping4, Topping5);
            Pizzas.Add(p);
            Price += p.Price;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var p in Pizzas) {
                sb.AppendLine(p.ToString());
            }
            return $"You have ordered these pizzas: {sb.ToString()}";
        }
    }
}