using System.Collections.Generic;

namespace PizzaBox.Client.Models {
    public class PizzaViewModel {
        public List<string> Pizzas { get; set; }
        /*public int Id { get; set; }
        public int OrderId { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }
        public string Topping1 { get; set; }
        public string Topping2 { get; set; }
        public string Topping3 { get; set; }
        public string Topping4 { get; set; }
        public string Topping5 { get; set; }
        public double Price { get; set; }*/

        public PizzaViewModel() {
            Pizzas = new List<string>() {
                "Cheese pizza",
                "Meat lovers pizza",
                "Vegetarian pizza"
            };
        }
    }
}