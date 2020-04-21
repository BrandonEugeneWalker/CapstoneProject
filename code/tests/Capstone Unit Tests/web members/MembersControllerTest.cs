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
    ///     Tests the MembersController behavior
    /// </summary>
    [TestClass]
    public class MembersControllerTest
    {
        #region Methods

        [TestMethod]
        public void StandardConstructorIsValid()
        {
            var controller = new MembersController();

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void IndexPageWithLibrarianIsNotNull()
        {
            var controller = setupMembersControllerWithLibrarianSession();

            var result = controller.Index(null) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexPageMemberWillRedirectToHomeIndexWithNoParameter()
        {
            var controller = setupMembersControllerWithMemberSession();

            var result = controller.Index(null) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexPageLibrarianWillGoToHomeIndexWithBannedParameter()
        {
            var controller = setupMembersControllerWithLibrarianSession();

            var result = controller.Index("Banned") as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexPageLibrarianWillGoToHomeIndexWithUnbannedParameter()
        {
            var controller = setupMembersControllerWithLibrarianSession();

            var result = controller.Index("Unbanned") as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexPageLibrarianWillGoToHomeIndexWithOverdueParameter()
        {
            var controller = setupMembersControllerWithLibrarianSession();

            var result = controller.Index("Overdue") as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexPageWithoutSessionRedirectToHomeIndex()
        {
            var controller = setupMembersControllerWithoutSession();

            var result = controller.Index(null) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsPageIsNotNull()
        {
            var controller = setupMembersControllerWithMemberSession();

            var result = controller.Details(1) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsPageWithNullMemberIdIsNotNull()
        {
            var controller = setupMembersControllerWithMemberSession();

            var result = controller.Details(null) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsPageAsLibrarianIsNotNull()
        {
            var controller = setupMembersControllerWithLibrarianSession();

            var result = controller.Details(1) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsPageWillRedirectWithoutMemberSession()
        {
            var controller = setupMembersControllerWithoutSession();

            var result = controller.Details(1) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsPageWillRedirectWithoutLibrarianSession()
        {
            var controller = setupMembersControllerWithoutSession();

            var result = controller.Details(1) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatePageIsNotNull()
        {
            var controller = setupMembersControllerWithMemberSession();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateActionWithValidMemberIsValid()
        {
            var controller = setupMembersControllerWithMemberSession();

            var result = controller.Create(new Member()) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateActionWithInvalidEmployeeReturnsToCreate()
        {
            var controller = setupMembersControllerWithMemberSession();

            controller.ModelState.AddModelError("", "");

            var result = controller.Create(new Member()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditMemberPageWithValidIdIsValid()
        {
            var controller = setupMembersControllerWithMemberSession();

            var result = controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(Member));

            var model = (Member)result.Model;

            Assert.AreEqual(1, model.memberId);
        }

        [TestMethod]
        public void EditMemberPageWithInvalidIdIsNull()
        {
            var controller = setupMembersControllerWithMemberSession();

            var result = controller.Edit((int?)null) as ViewResult;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EditMemberPageWithInvalidMemberIsNull()
        {
            var controller = setupMembersControllerWithMemberSession();

            var result = controller.Edit(3) as ViewResult;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EditMemberPageWillRedirectWithoutSession()
        {
            var controller = setupMembersControllerWithoutSession();

            var result = controller.Edit(1) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditMemberActionWithValidIdIsNotNull()
        {
            var controller = setupMembersControllerWithMemberSession();

            var result = controller.Edit(new Member { memberId = 1, username = "", name = "", password = "", isBanned = 0, isLibrarian = 0 }) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditMemberActionWithInvalidIdIsNull()
        {
            var controller = setupMembersControllerWithMemberSession();

            controller.ModelState.AddModelError("", "");

            var result = controller.Edit(new Member { memberId = 2, username = "", name = "", password = "", isBanned = 0, isLibrarian = 0 }) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditActionWillRedirectWithoutSession()
        {
            var controller = setupMembersControllerWithoutSession();

            var create = controller.Edit(new Member { memberId = 2, username = "", name = "", password = "", isBanned = 0, isLibrarian = 0 }) as RedirectToRouteResult;

            Assert.IsNotNull(create);
        }

        [TestMethod]
        public void BanMemberRedirectsToIndex()
        {
            var controller = setupMembersControllerWithoutSession();

            var result = controller.BanMember(1) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UnBanMemberRedirectsToIndex()
        {
            var controller = setupMembersControllerWithoutSession();

            var result = controller.UnBanMember(1) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BannedLoginReturnsToView()
        {
            var controller = setupMembersControllerWithoutSession();

            var result = controller.BannedLogin();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ControllerDisposesResourcesValid()
        {
            var controller = setupMembersControllerWithMemberSession();

            var edit = controller.Edit(1) as ViewResult;

            controller.Dispose();

            Assert.IsNotNull(edit);
        }

        [TestMethod]
        public void LoginPageValidMemberLoginRedirects()
        {
            var controller = setupMembersControllerWithMemberSession();

            var result = controller.Login(new Member { memberId = 1, username = "username", password = "password" }) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoginPageValidLibrarianLoginRedirects()
        {
            var controller = setupMembersControllerWithLibrarianSession();

            var result = controller.Login(new Member { memberId = 1, username = "username", password = "password", isLibrarian = 1 }) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoggingOffClearsSession()
        {
            var controller = setupMembersControllerWithMemberSession();

            var result = controller.LogOff() as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        private static MembersController setupMembersControllerWithoutSession()
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

            var membersController = new MembersController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["currentMemberId"]).Returns(null);
            session.Setup(s => s["currentLibrarianId"]).Returns(null);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            membersController.ControllerContext = new ControllerContext(requestContext, membersController);

            return membersController;
        }

        private static MembersController setupMembersControllerWithLibrarianSession()
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

            context.Setup(x => x.Members.Find(1)).Returns(new Member { memberId = 1, username = "username", password = "password", isLibrarian = 1 });

            var mockedProductObjectResult = new Mock<TestableObjectResult<Product>>();
            mockedProductObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestProducts().GetEnumerator);
            context.Setup(x => x.retrieveAvailableProductsWithSearch("", "")).Returns(mockedProductObjectResult.Object);

            var mockedRentalObjectResult = new Mock<TestableObjectResult<ItemRental>>();
            mockedRentalObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestItemRentals().GetEnumerator());
            context.Setup(x => x.retrieveMembersRentals(1)).Returns(mockedRentalObjectResult.Object);

            var mockedAddressObjectResult = new Mock<TestableObjectResult<Address>>();
            mockedAddressObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestAddresses().GetEnumerator());
            context.Setup(x => x.retrieveMembersAddresses(1)).Returns(mockedAddressObjectResult.Object);

            var mockedMemberObjectResult = new Mock<TestableObjectResult<Member>>();
            mockedMemberObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestLibrarians().GetEnumerator());
            context.Setup(x => x.selectMemberByIdAndPassword("username", "password"))
                   .Returns(mockedMemberObjectResult.Object);

            var mockedEmptyMemberObjectResult = new Mock<TestableObjectResult<Member>>();
            mockedEmptyMemberObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestMembers().GetEnumerator());
            context.Setup(x => x.selectMemberByIdAndPassword("u53rN4m3", "wrongPassword"))
                   .Returns(mockedEmptyMemberObjectResult.Object);

            var membersController = new MembersController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["currentLibrarianId"]).Returns(1);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            membersController.ControllerContext = new ControllerContext(requestContext, membersController);

            return membersController;
        }

        private static MembersController setupMembersControllerWithMemberSession()
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

            context.Setup(x => x.Members.Find(1)).Returns(new Member { memberId = 1, username = "username", password = "password" });

            var mockedProductObjectResult = new Mock<TestableObjectResult<Product>>();
            mockedProductObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestProducts().GetEnumerator);
            context.Setup(x => x.retrieveAvailableProductsWithSearch("", "")).Returns(mockedProductObjectResult.Object);

            var mockedRentalObjectResult = new Mock<TestableObjectResult<ItemRental>>();
            mockedRentalObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestItemRentals().GetEnumerator());
            context.Setup(x => x.retrieveMembersRentals(1)).Returns(mockedRentalObjectResult.Object);

            var mockedAddressObjectResult = new Mock<TestableObjectResult<Address>>();
            mockedAddressObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestAddresses().GetEnumerator());
            context.Setup(x => x.retrieveMembersAddresses(1)).Returns(mockedAddressObjectResult.Object);

            var mockedMemberObjectResult = new Mock<TestableObjectResult<Member>>();
            mockedMemberObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestMembers().GetEnumerator());
            context.Setup(x => x.selectMemberByIdAndPassword("username", "password"))
                   .Returns(mockedMemberObjectResult.Object);

            var mockedEmptyMemberObjectResult = new Mock<TestableObjectResult<Member>>();
            mockedEmptyMemberObjectResult.Setup(x => x.GetEnumerator()).Returns(getTestMembers().GetEnumerator());
            context.Setup(x => x.selectMemberByIdAndPassword("u53rN4m3", "wrongPassword"))
                   .Returns(mockedEmptyMemberObjectResult.Object);

            var membersController = new MembersController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["currentMemberId"]).Returns(1);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            membersController.ControllerContext = new ControllerContext(requestContext, membersController);

            return membersController;
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

            var testRentals = new List<ItemRental> { itemRentalA, itemRentalB };

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
                password = "P@ss12",
                isLibrarian = 1
            };

            var testMembers = new List<Member> { memberA, memberB };

            return testMembers;
        }

        private static List<Member> getTestLibrarians()
        {
            var memberA = new Member
            {
                memberId = 1,
                username = "UserName1",
                password = "P@ss12",
                isLibrarian = 1
            };
            var memberB = new Member
            {
                memberId = 2,
                username = "UserName2",
                password = "P@ss12",
                isLibrarian = 1
            };

            var testMembers = new List<Member> { memberA, memberB };

            return testMembers;
        }

        #endregion
    }
}