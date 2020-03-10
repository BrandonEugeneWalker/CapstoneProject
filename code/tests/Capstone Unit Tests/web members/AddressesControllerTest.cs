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
        public void CreateViewIsNotNull()
        {
            var context = new Mock<OnlineEntities>();
            var addressesController = new AddressesController(context.Object);
            var create = addressesController.Create() as ViewResult;
            Assert.IsNotNull(create);
        }


        //TODO NEED SESSION MOCK
        [TestMethod]
        public void CreatingNewAddressIsValid()
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
            var addressesController = new AddressesController(context.Object);
            var create = addressesController.Create(address1) as RedirectToRouteResult;
            Assert.IsNotNull(create);
        }

        [TestMethod]
        public void CreatingInvalidAddressReturnsToCreate()
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
            var addressesController = new AddressesController(context.Object);
            addressesController.ModelState.AddModelError("", "");
            var create = addressesController.Create(new Address()) as RedirectToRouteResult;
            Assert.IsNull(create);
        }

        /// <summary>
        ///     Tests editing an addressId in the Address Table does not change the addressId and that the page is run correctly by
        ///     the AddressesController
        /// </summary>
        [TestMethod]
        public void EditAddressWithValidId()
        {
            var address1 = new Address
                {addressId = 1, address1 = "1234 St", city = "Atlanta", state = "GA", zip = 12345, memberId = 1};
            var address2 = new Address
                {addressId = 2, address1 = "4321 Dr", city = "Atlanta", state = "GA", zip = 12345, memberId = 1};

            IList<Address> addresses = new List<Address> {
                address1, address2
            };

            var context = new Mock<OnlineEntities>();
            var mock = createDbSetMock(addresses);

            context.Setup(x => x.Addresses).Returns(mock.Object);
            context.Setup(x => x.Addresses.Find(1)).Returns(address1);
            var addressesController = new AddressesController(context.Object);
            var edit = addressesController.Edit(1) as ViewResult;
            Assert.IsNotNull(edit);
            Assert.IsNotNull(edit.Model);
            Assert.IsInstanceOfType(edit.Model, typeof(Address));
            var model = (Address) edit.Model;
            Assert.AreEqual(1, model.addressId);
        }

        [TestMethod]
        public void EditAddressWithInvalidId()
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

            var addressesController = new AddressesController(context.Object);
            var edit = addressesController.Edit((int?) null) as ViewResult;
            Assert.IsNull(edit);
        }

        [TestMethod]
        public void EditAddressWithInvalidAddress()
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

            var addressesController = new AddressesController(context.Object);
            var edit = addressesController.Edit(3) as ViewResult;
            Assert.IsNull(edit);
        }

        /// <summary>
        ///     Tests editing an addressId in the Address Table does not change the addressId and that the page is run correctly by
        ///     the AddressesController
        /// </summary>
        [TestMethod]
        public void EditPostAddressWithValidAddress()
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
            var addressesController = new AddressesController(context.Object);
            var edit = addressesController.Edit(address1) as RedirectToRouteResult;
            Assert.IsNotNull(edit);
        }

        [TestMethod]
        public void EditPostAddressWithInvalidAddress()
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
            var addressesController = new AddressesController(context.Object);
            addressesController.ModelState.AddModelError("","");
            var edit = addressesController.Edit(new Address()) as RedirectToRouteResult;
            Assert.IsNull(edit);
        }

        [TestMethod]
        public void RemoveAddressFromProfileIsValid()
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
            context.Setup(x => x.removeAddress(1)).Returns(1);
            var addressesController = new AddressesController(context.Object);
            var remove = addressesController.Remove(address1.addressId, null) as RedirectToRouteResult;
            Assert.IsNotNull(remove);
        }

        [TestMethod]
        public void RemoveAddressFromOrderIsValid()
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
            context.Setup(x => x.removeAddress(1)).Returns(1);
            var addressesController = new AddressesController(context.Object);
            var removeAtOrder = addressesController.Remove(address1.addressId, 1) as RedirectToRouteResult;
            Assert.IsNotNull(removeAtOrder);
        }

        [TestMethod]
        public void ControllerDisposesResourcesValid()
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

            var addressesController = new AddressesController(context.Object);
            var edit = addressesController.Edit(1) as ViewResult;
            addressesController.Dispose();
            Assert.IsNotNull(edit);
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