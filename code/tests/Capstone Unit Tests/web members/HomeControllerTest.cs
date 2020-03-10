using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database.Model;
using Capstone_Web_Members.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.web_members
{
    /// <summary>
    ///     Tests the HomeController behavior
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        #region Methods

        /// <summary>
        ///     Tests that the Index redirect is not null
        /// </summary>
        [TestMethod]
        public void Index_IsNotNull()
        {
            var context = new Mock<OnlineEntities>();

            var controller = new HomeController(context.Object);

            var result = controller.Index() as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///     Tests that the Media Library is not null
        /// </summary>
        [TestMethod]
        public void MediaLibrary_IsNotNull()
        {
            var context = new Mock<OnlineEntities>();
            var mockMembers = createDbSetMock(getTestMembers());
            var mockProducts = createDbSetMock(getTestProducts());
            var mockStock = createDbSetMock(getTestStocks());
            var mockAddresses = createDbSetMock(getTestAddresses());
            var mockRentals = createDbSetMock(getTestItemRentals());

            context.Setup(x => x.Members).Returns(mockMembers.Object);
            context.Setup(x => x.Products).Returns(mockProducts.Object);
            context.Setup(x => x.Stocks).Returns(mockStock.Object);
            context.Setup(x => x.Addresses).Returns(mockAddresses.Object);
            context.Setup(x => x.ItemRentals).Returns(mockRentals.Object);

            var controller = new HomeController(context.Object);

            var result = controller.MediaLibrary(null, null) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        /// <summary>
        ///     Tests that the ActionResult for OrderProduct is not null within the mock
        /// </summary>
        [TestMethod]
        public void OrderProduct_IsNotNull()
        {
            var context = new Mock<OnlineEntities>();
            var mockMembers = createDbSetMock(getTestMembers());
            var mockProducts = createDbSetMock(getTestProducts());
            var mockStock = createDbSetMock(getTestStocks());
            var mockAddresses = createDbSetMock(getTestAddresses());
            var mockRentals = createDbSetMock(getTestItemRentals());

            context.Setup(x => x.Members).Returns(mockMembers.Object);
            context.Setup(x => x.Products).Returns(mockProducts.Object);
            context.Setup(x => x.Stocks).Returns(mockStock.Object);
            context.Setup(x => x.Addresses).Returns(mockAddresses.Object);
            context.Setup(x => x.ItemRentals).Returns(mockRentals.Object);

            var controller = new HomeController(context.Object);

            var result = controller.OrderProduct(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        /// <summary>
        ///     Tests that the ActionResult for OrderProduct is not null within the mock
        /// </summary>
        [TestMethod]
        public void OrderProduct_Action_IsNotNull()
        {
            var context = new Mock<OnlineEntities>();
            var mockMembers = createDbSetMock(getTestMembers());
            var mockProducts = createDbSetMock(getTestProducts());
            var mockStock = createDbSetMock(getTestStocks());
            var mockAddresses = createDbSetMock(getTestAddresses());
            var mockRentals = createDbSetMock(getTestItemRentals());

            context.Setup(x => x.Members).Returns(mockMembers.Object);
            context.Setup(x => x.Products).Returns(mockProducts.Object);
            context.Setup(x => x.Stocks).Returns(mockStock.Object);
            context.Setup(x => x.Addresses).Returns(mockAddresses.Object);
            context.Setup(x => x.ItemRentals).Returns(mockRentals.Object);

            var controller = new HomeController(context.Object);

            var result = controller.OrderProduct("1", "1") as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        /// <summary>
        ///     Tests that the ActionResult for OrderProduct is not null within the mock
        /// </summary>
        [TestMethod]
        public void OrderConfirmation_Action_IsNotNull()
        {
            var context = new Mock<OnlineEntities>();
            var mockMembers = createDbSetMock(getTestMembers());
            var mockProducts = createDbSetMock(getTestProducts());
            var mockStock = createDbSetMock(getTestStocks());
            var mockAddresses = createDbSetMock(getTestAddresses());
            var mockRentals = createDbSetMock(getTestItemRentals());

            context.Setup(x => x.Members).Returns(mockMembers.Object);
            context.Setup(x => x.Products).Returns(mockProducts.Object);
            context.Setup(x => x.Stocks).Returns(mockStock.Object);
            context.Setup(x => x.Addresses).Returns(mockAddresses.Object);
            context.Setup(x => x.ItemRentals).Returns(mockRentals.Object);

            var controller = new HomeController(context.Object);

            var result = controller.OrderConfirmation(1, 1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        private static Mock<DbSet<T>> createDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }

        private static List<Product> getTestProducts()
        {
            var productA = new Product {
                productId = 1,
                name = "The Hobbit",
                description = "One small boi goes on an adventure",
                type = "Book",
                category = "Adventure"
            };
            var productB = new Product {
                productId = 2,
                name = "Fellowship of the Ring",
                description = "The first movie",
                type = "Movie",
                category = "Fantasy"
            };

            var testProducts = new List<Product> {productA, productB};

            return testProducts;
        }

        private static List<Stock> getTestStocks()
        {
            var stockA = new Stock {
                stockId = 1,
                productId = 1
            };
            var stockB = new Stock {
                stockId = 2,
                productId = 2
            };
            var stockC = new Stock {
                stockId = 3,
                productId = 1
            };
            var stockD = new Stock {
                stockId = 4,
                productId = 2
            };

            var testStock = new List<Stock> {stockA, stockB, stockC, stockD};

            return testStock;
        }

        private static List<ItemRental> getTestItemRentals()
        {
            var itemRentalA = new ItemRental {
                itemRentalId = 1,
                stockId = 3,
                memberId = 1,
                addressId = 1,
                status = "Returned"
            };
            var itemRentalB = new ItemRental {
                itemRentalId = 2,
                stockId = 4,
                memberId = 1,
                addressId = 2,
                status = "WaitingReturn"
            };

            var testRentals = new List<ItemRental> {itemRentalA, itemRentalB};

            return testRentals;
        }

        private static List<Address> getTestAddresses()
        {
            var addressA = new Address {
                addressId = 1,
                address1 = "555 St",
                city = "Atlanta",
                state = "Georgia",
                zip = 55555,
                memberId = 1
            };

            var addressB = new Address {
                addressId = 2,
                address1 = "666 Dr",
                city = "Temple",
                state = "Georgia",
                zip = 66666,
                memberId = 1
            };

            var testAddresses = new List<Address> {addressA, addressB};

            return testAddresses;
        }

        private static List<Member> getTestMembers()
        {
            var memberA = new Member {
                memberId = 1,
                username = "UserName1",
                password = "P@ss12"
            };
            var memberB = new Member {
                memberId = 2,
                username = "UserName2",
                password = "P@ss12"
            };

            var testMembers = new List<Member> {memberA, memberB};

            return testMembers;
        }

        #endregion
    }
}