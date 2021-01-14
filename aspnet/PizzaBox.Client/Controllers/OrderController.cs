using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    private readonly PizzaBoxContext _ctx;
    public OrderController(PizzaBoxContext context)
    {
      _ctx = context;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post(OrderViewModel model)
    {
      if (ModelState.IsValid)
      {
        var order = new Order()
        {
          Store = _ctx.Stores.FirstOrDefault(s => s.Name == model.Store),
          User = _ctx.Users.FirstOrDefault(u => u.Name == model.User)
        };

        order.MakePizza(model.Crust, model.Size, model.Topping1, model.Topping2, model.Topping3, model.Topping4, model.Topping5);
        _ctx.Order.Add(order);
        _ctx.SaveChanges();
        
        return View("OrderPlaced");
      }
      Console.WriteLine(model.ToString());

      return View("home", model);
    }
  }
}