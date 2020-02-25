using System.Collections.Generic;
using System.Web.Mvc;
using Capstone_Database.Model;
using Capstone_Web_Members.Controllers;
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.web_members
{
    /// <summary>
    /// Tests the MembersController behavior
    /// </summary>
    [TestClass]
    public class MembersControllerTest
    {
        private static Mock<MemberContext> getMemberContext()
        {
            var memberContextMock = new Mock<MemberContext>();

            var mockIntResult = new TestableObjectResult<int?>();
            memberContextMock.Setup(x => x.retrieveRentedCount(0))
                             .Returns(mockIntResult);
            var mockedIntResult = new Mock<TestableObjectResult<int?>>();
            mockedIntResult.Setup(x => x.GetEnumerator()).Returns(new List<int?> { 1, 2, 3 }.GetEnumerator());
            memberContextMock.Setup(x => x.retrieveRentedCount(0)).Returns(mockIntResult);
            return memberContextMock;
        }

        /// <summary>
        /// Tests that the Index Page is not null.
        /// </summary>
        [TestMethod]
        public void Index_IsNotNull()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
