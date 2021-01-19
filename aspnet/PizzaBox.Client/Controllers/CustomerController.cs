using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.Storing;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;

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
    public IActionResult NewUser()
    {
      var customer = new CustomerViewModel();

      customer.Order = new OrderViewModel()
      {
        Users = _ctx.GetUsers()
      };
      return View("createuser", customer.Order);
    }

    [HttpGet]
    public IActionResult MakeOrder()
    {
      var customer = new CustomerViewModel();

      customer.Order = new OrderViewModel()
      {
        Stores = _ctx.GetStores(),
        Users = _ctx.GetUsers()
      };
      return View("order", customer.Order);
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
        Orders = _ctx.GetOrdersByUser(model.User),
        Users = _ctx.GetUsers()
      };
      
      return View("CustomerOrders", customer.Order);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateUser(OrderViewModel model)
    {
      foreach(string u in _ctx.GetUsers()) {
        if(model.User == u) return View("createusererror");
      }
      var newUser = new User()
      {
        Name = model.User
      };

      _ctx.AddUser(newUser);
      _ctx.ContextSaveChanges();

      return View("UserCreated");
    }
  }
}