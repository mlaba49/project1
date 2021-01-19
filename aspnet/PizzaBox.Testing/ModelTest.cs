using System.Collections.Generic;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing {
    public class ModelTest {
        [Fact]
        private void Test_PizzaExists() {
            var sut = new Pizza("normal", "medium", "cheese", "pepperoni", "", "", "");

            Assert.IsType<Pizza>(sut);
            Assert.NotNull(sut);
        }
        [Fact]
        private void Test_OrderExists() {
            var sut = new Order();

            Assert.IsType<Order>(sut);
            Assert.NotNull(sut);
        }
        [Fact]
        private void Test_StoreExists() {
            var sut = new Store();
            
            Assert.IsType<Store>(sut);
            Assert.NotNull(sut);
        }
        [Fact]
        private void Test_UserExists() {
            var sut = new User();

            Assert.IsType<User>(sut);
            Assert.NotNull(sut);
        }
    }
}