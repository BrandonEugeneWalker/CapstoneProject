using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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

        [TestMethod]
        public void StandardConstructorIsValid()
        {
            var controller = new HomeController();

            Assert.IsNotNull(controller);
        }

        /// <summary>
        ///     Tests that the Index redirect is not null
        /// </summary>
        [TestMethod]
        public void IndexIsNotNull()
        {
            var homeController = setupHomeControllerWithMemberSession();

            var result = homeController.Index() as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///     Tests that the Index redirect is not null
        /// </summary>
        [TestMethod]
        public void IndexRedirectsLibrariansToMemberIndex()
        {
            var homeController = setupHomeControllerWithLibrarianSession();

            var result = homeController.Index() as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///     Tests that the Media Library is not null
        /// </summary>
        [TestMethod]
        public void MediaLibraryIsNotNull()
        {
            var homeController = setupHomeControllerWithMemberSession();

            var result = homeController.MediaLibrary(null, null) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        /// <summary>
        ///     Tests that the Media Library will set IsLibrarian to true if a Librarian is logged in
        /// </summary>
        [TestMethod]
        public void MediaLibraryLibrariansFlagged()
        {
            var homeController = setupHomeControllerWithLibrarianSession();

            var result = homeController.MediaLibrary(null, null) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        /// <summary>
        ///     Tests that the Media Library is not null
        /// </summary>
        [TestMethod]
        public void MediaLibraryWillRedirectWithoutSession()
        {
            var homeController = setupHomeControllerWithoutSession();

            var result = homeController.MediaLibrary(null, null) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///     Tests that the ActionResult for OrderProduct is not null within the mock
        /// </summary>
        [TestMethod]
        public void OrderProductPageWithValidProductIdIsNotNull()
        {
            var homeController = setupHomeControllerWithMemberSession();

            var result = homeController.OrderProduct(1) as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///     Tests that the ActionResult for OrderProduct is not null within the mock
        /// </summary>
        [TestMethod]
        public void OrderProductPageWillRedirectWithoutSession()
        {
            var homeController = setupHomeControllerWithoutSession();

            var result = homeController.OrderProduct(1) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///     Tests that the ActionResult for OrderProduct is not null within the mock
        /// </summary>
        [TestMethod]
        public void OrderProductActionWithValidIdsIsNotNull()
        {
            var homeController = setupHomeControllerWithMemberSession();

            var result = homeController.OrderProduct("1", "1") as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///     Tests that the ActionResult for OrderProduct is not null within the mock
        /// </summary>
        [TestMethod]
        public void OrderProductActionWillRedirectWithoutSession()
        {
            var homeController = setupHomeControllerWithoutSession();

            var result = homeController.OrderProduct("1", "1") as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }
        
        /// <summary>
        ///     Tests that the ActionResult for OrderProduct is not null within the mock
        /// </summary>
        [TestMethod]
        public void OrderConfirmationWithValidIdsIsNotNull()
        {
            var homeController = setupHomeControllerWithMemberSession();

            var result = homeController.OrderConfirmation(1, 1) as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///     Tests that the ActionResult for OrderProduct is not null within the mock
        /// </summary>
        [TestMethod]
        public void OrderConfirmationWillRedirectWithoutSession()
        {
            var homeController = setupHomeControllerWithoutSession();

            var result = homeController.OrderConfirmation(1, 1) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        private static HomeController setupHomeControllerWithoutSession()
        {
            var context = new Mock<OnlineEntities>();
            var mockMembers = createDbSetMock(getTestMembers());
            var mockProducts = createDbSetMock(getTestProducts());
            var mockStock = createDbSetMock(getTestStocks());
            var mockAddresses = createDbSetMock(getTestAddresses());
            var mockRentals = createDbSetMock(getTestItemRentals());
            var testCounts = new List<int?> { 1, 2, 3 };

            context.Setup(x => x.Members).Returns(mockMembers.Object);
            context.Setup(x => x.Products).Returns(mockProducts.Object);
            context.Setup(x => x.Stocks).Returns(mockStock.Object);
            context.Setup(x => x.Addresses).Returns(mockAddresses.Object);
            context.Setup(x => x.ItemRentals).Returns(mockRentals.Object);

            var mockedProductObjectResult = new Mock<TestableObjectResult<Product>>();
            mockedProductObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestProducts().GetEnumerator);
            context.Setup(x => x.retrieveAvailableProductsWithSearch("", "")).Returns(mockedProductObjectResult.Object);

            var mockedIntObjectResult = new Mock<TestableObjectResult<int?>>();
            mockedIntObjectResult.Setup(x => x.GetEnumerator()).Returns(testCounts.GetEnumerator());
            context.Setup(x => x.retrieveRentedCount(1)).Returns(mockedIntObjectResult.Object);

            var homeController = new HomeController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["currentMemberId"]).Returns(null);
            session.Setup(s => s["currentLibrarianId"]).Returns(null);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            homeController.ControllerContext = new ControllerContext(requestContext, homeController);

            return homeController;
        }

        private static HomeController setupHomeControllerWithLibrarianSession()
        {
            var context = new Mock<OnlineEntities>();
            var mockMembers = createDbSetMock(getTestMembers());
            var mockProducts = createDbSetMock(getTestProducts());
            var mockStock = createDbSetMock(getTestStocks());
            var mockAddresses = createDbSetMock(getTestAddresses());
            var mockRentals = createDbSetMock(getTestItemRentals());
            var testCounts = new List<int?> { 1, 2, 3 };

            context.Setup(x => x.Members).Returns(mockMembers.Object);
            context.Setup(x => x.Products).Returns(mockProducts.Object);
            context.Setup(x => x.Stocks).Returns(mockStock.Object);
            context.Setup(x => x.Addresses).Returns(mockAddresses.Object);
            context.Setup(x => x.ItemRentals).Returns(mockRentals.Object);

            var mockedProductObjectResult = new Mock<TestableObjectResult<Product>>();
            mockedProductObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestProducts().GetEnumerator);
            context.Setup(x => x.retrieveAvailableProductsWithSearch("", "")).Returns(mockedProductObjectResult.Object);

            var mockedIntObjectResult = new Mock<TestableObjectResult<int?>>();
            mockedIntObjectResult.Setup(x => x.GetEnumerator()).Returns(testCounts.GetEnumerator());
            context.Setup(x => x.retrieveRentedCount(1)).Returns(mockedIntObjectResult.Object);
            context.Setup(x => x.findAvailableStockOfProduct(1)).Returns(mockedIntObjectResult.Object);

            var mockedAddressObjectResult = new Mock<TestableObjectResult<Address>>();
            mockedAddressObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestAddresses().GetEnumerator());
            context.Setup(x => x.retrieveMembersAddresses(1)).Returns(mockedAddressObjectResult.Object);


            var homeController = new HomeController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["currentLibrarianId"]).Returns(1);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            homeController.ControllerContext = new ControllerContext(requestContext, homeController);

            return homeController;
        }

        private static HomeController setupHomeControllerWithMemberSession()
        {
            var context = new Mock<OnlineEntities>();
            var mockMembers = createDbSetMock(getTestMembers());
            var mockProducts = createDbSetMock(getTestProducts());
            var mockStock = createDbSetMock(getTestStocks());
            var mockAddresses = createDbSetMock(getTestAddresses());
            var mockRentals = createDbSetMock(getTestItemRentals());
            var testCounts = new List<int?> { 1, 2, 3 };

            context.Setup(x => x.Members).Returns(mockMembers.Object);
            context.Setup(x => x.Products).Returns(mockProducts.Object);
            context.Setup(x => x.Stocks).Returns(mockStock.Object);
            context.Setup(x => x.Addresses).Returns(mockAddresses.Object);
            context.Setup(x => x.ItemRentals).Returns(mockRentals.Object);

            var mockedProductObjectResult = new Mock<TestableObjectResult<Product>>();
            mockedProductObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestProducts().GetEnumerator);
            context.Setup(x => x.retrieveAvailableProductsWithSearch("", "")).Returns(mockedProductObjectResult.Object);

            var mockedIntObjectResult = new Mock<TestableObjectResult<int?>>();
            mockedIntObjectResult.Setup(x => x.GetEnumerator()).Returns(testCounts.GetEnumerator());
            context.Setup(x => x.retrieveRentedCount(1)).Returns(mockedIntObjectResult.Object);
            context.Setup(x => x.findAvailableStockOfProduct(1)).Returns(mockedIntObjectResult.Object);

            var mockedAddressObjectResult = new Mock<TestableObjectResult<Address>>();
            mockedAddressObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestAddresses().GetEnumerator());
            context.Setup(x => x.retrieveMembersAddresses(1)).Returns(mockedAddressObjectResult.Object);


            var homeController = new HomeController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["currentMemberId"]).Returns(1);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            homeController.ControllerContext = new ControllerContext(requestContext, homeController);

            return homeController;
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

        private static IEnumerable<Product> getTestProducts()
        {
            var productA = new Product
            {
                productId = 1,
                name = "The Hobbit",
                description = "One small boi goes on an adventure",
                type = "Book",
                category = "Adventure"
            };
            var productB = new Product
            {
                productId = 2,
                name = "Fellowship of the Ring",
                description = "The first movie",
                type = "Movie",
                category = "Fantasy"
            };

            var testProducts = new List<Product> { productA, productB };

            return testProducts;
        }

        private static List<Stock> getTestStocks()
        {
            var stockA = new Stock
            {
                stockId = 1,
                productId = 1
            };
            var stockB = new Stock
            {
                stockId = 2,
                productId = 2
            };
            var stockC = new Stock
            {
                stockId = 3,
                productId = 1
            };
            var stockD = new Stock
            {
                stockId = 4,
                productId = 2
            };

            var testStock = new List<Stock> { stockA, stockB, stockC, stockD };

            return testStock;
        }

        private static List<ItemRental> getTestItemRentals()
        {
            var itemRentalA = new ItemRental
            {
                itemRentalId = 1,
                stockId = 3,
                memberId = 1,
                addressId = 1,
                status = "Returned"
            };
            var itemRentalB = new ItemRental
            {
                itemRentalId = 2,
                stockId = 4,
                memberId = 1,
                addressId = 2,
                status = "WaitingReturn"
            };
            var itemRentalC = new ItemRental
            {
                itemRentalId = 3,
                stockId = 5,
                memberId = 1,
                addressId = 2,
                status = "WaitingReturn"
            };

            var testRentals = new List<ItemRental> { itemRentalA, itemRentalB, itemRentalC };

            return testRentals;
        }

        private static List<Address> getTestAddresses()
        {
            var addressA = new Address
            {
                addressId = 1,
                address1 = "555 St",
                city = "Atlanta",
                state = "Georgia",
                zip = 55555,
                memberId = 1
            };

            var addressB = new Address
            {
                addressId = 2,
                address1 = "666 Dr",
                city = "Temple",
                state = "Georgia",
                zip = 66666,
                memberId = 1
            };

            var testAddresses = new List<Address> { addressA, addressB };

            return testAddresses;
        }

        private static List<Member> getTestMembers()
        {
            var memberA = new Member
            {
                memberId = 1,
                username = "UserName1",
                password = "P@ss12"
            };
            var memberB = new Member
            {
                memberId = 2,
                username = "UserName2",
                password = "P@ss12"
            };

            var testMembers = new List<Member> { memberA, memberB };

            return testMembers;
        }

        #endregion
    }
}