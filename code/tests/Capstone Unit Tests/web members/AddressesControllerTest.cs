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
    ///     Tests the AddressesController behavior
    /// </summary>
    [TestClass]
    public class AddressesControllerTest
    {
        #region Methods

        [TestMethod]
        public void StandardConstructorIsValid()
        {
            var addressesController = new AddressesController();

            Assert.IsNotNull(addressesController);
        }

        [TestMethod]
        public void CreatePageIsNotNull()
        {
            var addressesController = setupAddressesControllerWithSession();

            var create = addressesController.Create(null as int?) as ViewResult;

            Assert.IsNotNull(create);
        }

        [TestMethod]
        public void CreatePageWillRedirectWithoutSession()
        {
            var addressesController = setupAddressesControllerWithoutSession();

            var create = addressesController.Create(null as int?) as RedirectToRouteResult;

            Assert.IsNotNull(create);
        }

        [TestMethod]
        public void CreateActionWithValidAddressIsNotNull()
        {
            var addressesController = setupAddressesControllerWithSession();

            var address1 = new Address
                { addressId = 1, address1 = "1234 St", city = "Atlanta", state = "GA", zip = 12345, memberId = 1 };
            var create = addressesController.Create(address1) as RedirectToRouteResult;

            Assert.IsNotNull(create);
        }

        [TestMethod]
        public void CreateActionWithValidAddressAndProductIdRedirects()
        {
            var addressesController = setupAddressesControllerWithSessionMemberIdAndProductId();

            var address1 = new Address
                { addressId = 1, address1 = "1234 St", city = "Atlanta", state = "GA", zip = 12345, memberId = 1 };
            var create = addressesController.Create(address1) as RedirectToRouteResult;

            Assert.IsNotNull(create);
        }

        [TestMethod]
        public void CreateActionWithInvalidAddressReturnsToCreate()
        {
            var addressesController = setupAddressesControllerWithSession();

            addressesController.ModelState.AddModelError("", "");

            var address1 = new Address
                { addressId = 1, address1 = "1234 St", city = "Atlanta", state = "GA", zip = 12345, memberId = 1 };
            var create = addressesController.Create(address1) as RedirectToRouteResult;

            Assert.IsNull(create);
        }

        [TestMethod]
        public void CreatingAddressWillRedirectWithoutSession()
        {
            var addressesController = setupAddressesControllerWithoutSession();

            var address1 = new Address
                { addressId = 1, address1 = "1234 St", city = "Atlanta", state = "GA", zip = 12345, memberId = 1 };
            var create = addressesController.Create(address1) as RedirectToRouteResult;

            Assert.IsNotNull(create);
        }

        [TestMethod]
        public void EditPageWithValidIdIsValid()
        {
            var addressesController = setupAddressesControllerWithSession();

            var edit = addressesController.Edit(1, null) as ViewResult;

            Assert.IsNotNull(edit);
            Assert.IsNotNull(edit.Model);
            Assert.IsInstanceOfType(edit.Model, typeof(Address));

            var model = (Address) edit.Model;

            Assert.AreEqual(1, model.addressId);
        }

        [TestMethod]
        public void EditPageWithInvalidIdIsNull()
        {
            var addressesController = setupAddressesControllerWithSession();

            var edit = addressesController.Edit(null, null) as ViewResult;

            Assert.IsNull(edit);
        }

        [TestMethod]
        public void EditPageWithInvalidAddressIsNull()
        {
            var addressesController = setupAddressesControllerWithSession();

            var edit = addressesController.Edit(3, null) as ViewResult;

            Assert.IsNull(edit);
        }

        [TestMethod]
        public void EditPageWillRedirectWithoutSession()
        {
            var addressesController = setupAddressesControllerWithoutSession();

            var create = addressesController.Edit(1, null) as RedirectToRouteResult;

            Assert.IsNotNull(create);
        }

        [TestMethod]
        public void EditActionWithValidAddressIsNotNull()
        {
            var addressesController = setupAddressesControllerWithSession();

            var edit = addressesController.Edit(new Address()) as RedirectToRouteResult;

            Assert.IsNotNull(edit);
        }

        [TestMethod]
        public void EditActionWithValidAddressAndProductIdRedirects()
        {
            var addressesController = setupAddressesControllerWithSessionMemberIdAndProductId();

            var edit = addressesController.Edit(new Address()) as RedirectToRouteResult;

            Assert.IsNotNull(edit);
        }

        [TestMethod]
        public void EditActionWithInvalidAddressIsNull()
        {
            var addressesController = setupAddressesControllerWithSession();

            addressesController.ModelState.AddModelError("","");

            var edit = addressesController.Edit(new Address()) as RedirectToRouteResult;

            Assert.IsNull(edit);
        }

        [TestMethod]
        public void EditActionWillRedirectWithoutSession()
        {
            var addressesController = setupAddressesControllerWithoutSession();

            var create = addressesController.Edit(new Address()) as RedirectToRouteResult;

            Assert.IsNotNull(create);
        }

        [TestMethod]
        public void RemoveActionWithoutProductIdRedirectsToProfile()
        {
            var addressesController = setupAddressesControllerWithSession();

            var remove = addressesController.Remove(1, null) as RedirectToRouteResult;

            Assert.IsNotNull(remove);
        }

        [TestMethod]
        public void RemoveActionWithProductIdRedirectsToOrderProduct()
        {
            var addressesController = setupAddressesControllerWithSession();

            var removeAtOrder = addressesController.Remove(1, 1) as RedirectToRouteResult;

            Assert.IsNotNull(removeAtOrder);
        }

        [TestMethod]
        public void RemoveAddressWillRedirectWithoutSession()
        {
            var addressesController = setupAddressesControllerWithoutSession();

            var remove = addressesController.Remove(1, null) as RedirectToRouteResult;

            Assert.IsNotNull(remove);
        }

        [TestMethod]
        public void ControllerDisposesResourcesValid()
        {
            var addressesController = setupAddressesControllerWithSession();

            var edit = addressesController.Edit(1, null) as ViewResult;

            addressesController.Dispose();

            Assert.IsNotNull(edit);
        }

        private static AddressesController setupAddressesControllerWithoutSession()
        {
            var address1 = new Address
                { addressId = 1, address1 = "1234 St", city = "Atlanta", state = "GA", zip = 12345, memberId = 1 };
            var address2 = new Address
                { addressId = 2, address1 = "4321 Dr", city = "Atlanta", state = "GA", zip = 12345, memberId = 1 };

            IList<Address> addresses = new List<Address> {
                address1, address2
            };

            var context = new Mock<OnlineEntities>();
            var mock = createDbSetMock(addresses);

            context.Setup(x => x.Addresses).Returns(mock.Object);
            context.Setup(x => x.Addresses.Find(1)).Returns(address1);
            context.Setup(x => x.insertAddress(address1.address1, 1, address1.address2, address1.city, address1.state, address1.zip)).Returns(1);
            context.Setup(x => x.removeAddress(1)).Returns(1);

            var addressesController = new AddressesController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["currentMemberId"]).Returns(null);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            addressesController.ControllerContext = new ControllerContext(requestContext, addressesController);

            return addressesController;
        }

        private static AddressesController setupAddressesControllerWithSessionMemberIdAndProductId()
        {
            var address1 = new Address
                { addressId = 1, address1 = "1234 St", city = "Atlanta", state = "GA", zip = 12345, memberId = 1 };
            var address2 = new Address
                { addressId = 2, address1 = "4321 Dr", city = "Atlanta", state = "GA", zip = 12345, memberId = 1 };

            IList<Address> addresses = new List<Address> {
                address1, address2
            };

            var context = new Mock<OnlineEntities>();
            var mock = createDbSetMock(addresses);

            context.Setup(x => x.Addresses).Returns(mock.Object);
            context.Setup(x => x.Addresses.Find(1)).Returns(address1);
            context.Setup(x => x.insertAddress(address1.address1, 1, address1.address2, address1.city, address1.state, address1.zip)).Returns(1);
            context.Setup(x => x.removeAddress(1)).Returns(1);

            var addressesController = new AddressesController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["currentMemberId"]).Returns(1);
            session.Setup(s => s["productId"]).Returns(1);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            addressesController.ControllerContext = new ControllerContext(requestContext, addressesController);

            return addressesController;
        }

        private static AddressesController setupAddressesControllerWithSession()
        {
            var address1 = new Address
                { addressId = 1, address1 = "1234 St", city = "Atlanta", state = "GA", zip = 12345, memberId = 1 };
            var address2 = new Address
                { addressId = 2, address1 = "4321 Dr", city = "Atlanta", state = "GA", zip = 12345, memberId = 1 };

            IList<Address> addresses = new List<Address> {
                address1, address2
            };

            var context = new Mock<OnlineEntities>();
            var mock = createDbSetMock(addresses);

            context.Setup(x => x.Addresses).Returns(mock.Object);
            context.Setup(x => x.Addresses.Find(1)).Returns(address1);
            context.Setup(x => x.insertAddress(address1.address1, 1, address1.address2, address1.city, address1.state, address1.zip)).Returns(1);
            context.Setup(x => x.removeAddress(1)).Returns(1);

            var addressesController = new AddressesController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["currentMemberId"]).Returns(1);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            addressesController.ControllerContext = new ControllerContext(requestContext, addressesController);

            return addressesController;
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

        #endregion
    }
}