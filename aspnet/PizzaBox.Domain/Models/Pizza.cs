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
            Price = 9.99;
            if(Crust == "CHEESE") Price += 5;
            if(Size == "SMALL") Price -= 5;
            if(Size == "LARGE") Price += 5;
            if(Topping1 != "" && Topping1 != "NONE") Price += 5;
            if(Topping2 != "" && Topping2 != "NONE") Price += 5;
            if(Topping3 != "" && Topping3 != "NONE") Price += 5;
            if(Topping4 != "" && Topping4 != "NONE") Price += 5;
            if(Topping5 != "" && Topping5 != "NONE") Price += 5;
        }

    }
}