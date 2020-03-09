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

        //TODO REMOVE
        private static Mock<MemberContext> getMemberContext()
        {
            var memberContextMock = new Mock<MemberContext>();

            var mockProductsResult = new TestableObjectResult<Product>();
            memberContextMock.Setup(x => x.retrieveAvailableProductsWithSearch(string.Empty, string.Empty))
                             .Returns(mockProductsResult);
            var mockedProductResult = new Mock<TestableObjectResult<Product>>();
            mockedProductResult.Setup(x => x.GetEnumerator()).Returns(getTestProducts().GetEnumerator());
            memberContextMock.Setup(x => x.retrieveAvailableProductsWithSearch(string.Empty, string.Empty))
                             .Returns(mockedProductResult.Object);

            var mockIntResult = new TestableObjectResult<int?>();
            memberContextMock.Setup(x => x.retrieveRentedCount(0))
                             .Returns(mockIntResult);
            var mockedIntResult = new Mock<TestableObjectResult<int?>>();
            mockedIntResult.Setup(x => x.GetEnumerator()).Returns(new List<int?> {1, 2, 3}.GetEnumerator());
            memberContextMock.Setup(x => x.retrieveRentedCount(0)).Returns(mockIntResult);

            return memberContextMock;
        }

        //TODO The way that MediaLibrary gets the count of rentals is
        //TODO flawed and prevents testing being finished. REWORK
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

            // Act
            var result = controller.MediaLibrary(null, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        /// <summary>
        ///     Tests that the Media Library model is not null
        /// </summary>
        [TestMethod]
        public void MediaLibrary_ModelIsNotNull()
        {
            // Arrange
            var controller = new HomeController(getMemberContext().Object);

            // Act
            var result = controller.MediaLibrary(null, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result?.Model);
        }

        //TODO -Will need further in depth testing, does not reach the ActionResult as
        //TODO -it is triggered by a link, but uses the controllers properties
        /// <summary>
        ///     Tests that the ActionResult for OrderProduct is not null within the mock
        /// </summary>
        [TestMethod]
        public void OrderProduct_Action_IsNotNull()
        {
            // Arrange
            var controller = new HomeController(getMemberContext().Object);

            // Act
            var result = controller.OrderProduct(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReturnProduct_Action_IsNotNull()
        {
            // Arrange
            var controller = new HomeController(getMemberContext().Object);

            // Act
            var result = controller.OrderProduct(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
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