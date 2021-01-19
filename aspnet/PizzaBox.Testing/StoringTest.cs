using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing;
using Xunit;

namespace PizzaBox.Testing {
    public class StoringTest {
        [Fact]
        private void Test_ContextExists() {
            var sut = new PizzaBoxContext(new DbContextOptions<PizzaBoxContext>());

            Assert.IsType<PizzaBoxContext>(sut);
            Assert.NotNull(sut);
        }
        [Fact]
        private void Test_RepositoryExists() {
            var sut = new PizzaBoxRepository(new PizzaBoxContext(new DbContextOptions<PizzaBoxContext>()));

            Assert.IsType<PizzaBoxRepository>(sut);
            Assert.NotNull(sut);
        }
    }
}