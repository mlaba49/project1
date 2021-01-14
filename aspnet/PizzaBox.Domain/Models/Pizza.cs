using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
    public class Pizza : APizzaModel {

        public Pizza() {
            EntityId = 0;
        }

        public Pizza(string _Crust, string _Size, string _Topping1, string _Topping2, string _Topping3, string _Topping4, string _Topping5) {
            AddCrust(_Crust);
            AddSize(_Size);
            AddToppings(_Topping1, _Topping2, _Topping3, _Topping4, _Topping5);
        }

    }
}