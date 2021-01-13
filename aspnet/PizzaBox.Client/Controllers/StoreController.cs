using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers {
    [Route("[controller]")]
    public class StoreController : Controller {
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

        /*public void Post() {}
        public void Put() {}
        public void Delete() {}*/
    }
}