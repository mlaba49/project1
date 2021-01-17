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
        public IActionResult Get() {
            var stores = new StoreViewModel(); //static type inference
            /*dynamic stores2 = new StoreViewModel();
            stores2 = 10;*/

            //1-way data binding
            ViewBag.Stores = stores.Stores; //dynamic object
            ViewData["Stores"] = stores.Stores; //dictionary object, dictionary<string, object>

            //redirect data binding
            TempData["Stores"] = stores.Stores;

            return View("StrongStore", new StoreViewModel());
        }

        [HttpGet("{store}")]
        public IActionResult Get(string store) {
            return View("Store", store);
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
                Orders = _ctx.GetOrders(),
                Pizzas = _ctx.GetPizzasByStore(model.Store),
                Users = _ctx.GetUsers()
            };
      
            return View("StoreOrders", customer.Order);
        }
    }
}