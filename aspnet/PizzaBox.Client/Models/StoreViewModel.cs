using System.Collections.Generic;

namespace PizzaBox.Client.Models {
    public class StoreViewModel {
        public List<string> Stores { get; set; }
        /*public int Id { get; set; }
        public string Name { get; set; }*/

        public StoreViewModel() {
            Stores = new List<string>() {
                "Dominos",
                "Pizza Hut",
                "Little Caesar's"
            };
        }
    }
}