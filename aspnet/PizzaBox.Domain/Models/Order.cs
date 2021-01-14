using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
    public class Order : AModel {
        public Store Store { get; set; }
        public User User { get; set; }
        public long StoreEntityId { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}