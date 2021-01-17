using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PizzaBox.Storing;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
    public List<string> Stores { get; set; }
    public List<string> Users { get; set; }
    public List<string> Orders { get; set; }
    public List<string> Pizzas { get; set; }

    [Required]
    public string Store { get; set; }

    [Required]
    public string User { get; set; }
    public string Size { get; set; }
    public string Crust { get; set; }
    public string Topping1 { get; set; }
    public string Topping2 { get; set; }
    public string Topping3 { get; set; }
    public string Topping4 { get; set; }
    public string Topping5 { get; set; }
        public override string ToString()
        {
            return "Store: " + Store + ", User: " + User + ", Size: " + Size + ", Crust: " + Crust + ", Topping 1: " + Topping1 + ", Topping 2: " + Topping2 + ", Topping 3: " + Topping3 + ", Topping 4: " + Topping4 + ", Topping 5: " + Topping5;
        }
  
  }
}