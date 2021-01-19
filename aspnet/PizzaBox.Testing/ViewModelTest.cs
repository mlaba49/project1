using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;
using Xunit;

namespace PizzaBox.Testing {
    public class ViewModelTest {
        [Fact]
        private void Test_CustomerViewModelExists() {
            var sut = new CustomerViewModel();

            Assert.IsType<CustomerViewModel>(sut);
            Assert.NotNull(sut);
        }
        [Fact]
        private void Test_ErrorViewModelExists() {
            var sut = new ErrorViewModel();

            Assert.IsType<ErrorViewModel>(sut);
            Assert.NotNull(sut);
        }
        [Fact]
        private void Test_OrderViewModelExists() {
            var sut = new OrderViewModel();

            Assert.IsType<OrderViewModel>(sut);
            Assert.NotNull(sut);
        }
    }
}