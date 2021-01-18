using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers {
    public class StoreController : Controller {
    private readonly PizzaBoxRepository _ctx;
        public StoreController(PizzaBoxRepository context)
        {
            _ctx = context;
        }

        [HttpGet]
        public IActionResult ViewStoreOrders()
        {
            var customer = new CustomerViewModel();

            customer.Order = new OrderViewModel()
            {
                Stores = _ctx.GetStores(),
                Users = _ctx.GetUsers()
            };
            return View("ViewStoreOrder", customer.Order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(OrderViewModel model)
        {
            var customer = new CustomerViewModel();

            customer.Order = new OrderViewModel()
            {
                Orders = _ctx.GetOrdersByStore(model.Store),
                Users = _ctx.GetUsers()
            };
      
            return View("StoreOrders", customer.Order);
        }
    }
}