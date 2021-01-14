using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.Storing;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class CustomerController : Controller
  {
    private readonly PizzaBoxRepository _ctx;
    public CustomerController(PizzaBoxRepository context)
    {
      _ctx = context;
    }

    [HttpGet]
    public IActionResult Home()
    {
      var customer = new CustomerViewModel();

      customer.Order = new OrderViewModel()
      {
        Stores = _ctx.GetStores(),
        Users = _ctx.GetUsers()
      };
      return View("home", customer.Order);
    }
  }
}