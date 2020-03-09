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

        public void Create_IsNotNull()
        {
        }

        public void CreatingNewAddressIsValid()
        {
        }

        public void CreatingInvalidAddressReturnsToCreate()
        {
        }

        /// <summary>
        ///     Tests editing an addressId in the Address Table does not change the addressId and that the page is run correctly by
        ///     the AddressesController
        /// </summary>
        [TestMethod]
        public void EditAddressIdWithValidEdit()
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

        public void EditingAddressToInvalidReturnsToEdit()
        {
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