using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers {
    [Route("[controller]")]
    public class PizzaController : Controller {
        [HttpGet]
        public IActionResult Get() {
            var pizzas = new PizzaViewModel();
            
            ViewBag.Pizzas = pizzas.Pizzas;

            return View("Pizza", new PizzaViewModel());
        }

        [HttpGet("{order}")]
        public IActionResult Get(string pizza) {
            return View("Pizza", pizza);
        }
    }
}