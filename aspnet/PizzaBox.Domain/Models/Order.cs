using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
    public class Order : AModel {
        public Store Store { get; set; }
        public User User { get; set; }
        public long StoreEntityId { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public double Price { get; set; }

        public Order() {
            Pizzas = new List<Pizza>();
        }

        public void MakePizza(string Crust, string Size, string Topping1, string Topping2, string Topping3, string Topping4, string Topping5) {
            Pizza p = new Pizza(Crust, Size, Topping1, Topping2, Topping3, Topping4, Topping5);
            Price += 9.99;
            if(p.Crust == "CHEESE") Price += 5;
            if(p.Size == "SMALL") Price -= 5;
            if(p.Size == "LARGE") Price += 5;
            if(Topping1 != "" && Topping1 != "NONE") Price += 5;
            if(Topping2 != "" && Topping2 != "NONE") Price += 5;
            if(Topping3 != "" && Topping3 != "NONE") Price += 5;
            if(Topping4 != "" && Topping4 != "NONE") Price += 5;
            if(Topping5 != "" && Topping5 != "NONE") Price += 5;
            Pizzas.Add(p);
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