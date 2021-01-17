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

    [HttpGet]
    public IActionResult ViewCustomerOrders()
    {
      var customer = new CustomerViewModel();

      customer.Order = new OrderViewModel()
      {
        Stores = _ctx.GetStores(),
        Users = _ctx.GetUsers()
      };
      return View("ViewCustomerOrder", customer.Order);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post(OrderViewModel model)
    {
      var customer = new CustomerViewModel();

      customer.Order = new OrderViewModel()
      {
        Orders = _ctx.GetOrders(),
        Pizzas = _ctx.GetPizzasByUser(model.User),
        Users = _ctx.GetUsers()
      };
      
      return View("CustomerOrders", customer.Order);
    }
  }
}