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

        _ctx.Order.Add(order);
        _ctx.SaveChanges();
        
        return View("OrderPlaced");
      }

      return View("home", model);
    }
  }
}