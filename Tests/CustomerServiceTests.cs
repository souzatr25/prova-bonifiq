using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaPub.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void ListEntity_ReturnsCorrectCustomerList()
        {
            // Arrange
            var dbContextMock = new Mock<TestDbContext>();
            var customerService = new CustomerService(dbContextMock.Object);

            // Mock data
            var customers = Enumerable.Range(1, 10).Select(i => new Customer()).ToList().AsQueryable();
            var mockSet = new Mock<DbSet<Customer>>().SetupData(customers);
            dbContextMock.Setup(ctx => ctx.Customers).Returns(mockSet.Object);

            // Act
            var result = customerService.ListEntity(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Customers.Count);
            Assert.IsTrue(result.HasNext);
            Assert.AreEqual(10, result.TotalCount);
        }

        [TestMethod]
        public async Task CanPurchase_InvalidCustomerId_ThrowsException()
        {
            // Arrange
            var dbContextMock = new Mock<TestDbContext>();
            var customerService = new CustomerService(dbContextMock.Object);

            // Act and Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => customerService.CanPurchase(0, 50));
        }

        [TestMethod]
        public async Task CanPurchase_InvalidPurchaseValue_ThrowsException()
        {
            // Arrange
            var dbContextMock = new Mock<TestDbContext>();
            var customerService = new CustomerService(dbContextMock.Object);

            // Act and Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => customerService.CanPurchase(1, -50));
        }
    }
}
