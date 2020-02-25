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
    /// Tests the MembersController behavior
    /// </summary>
    [TestClass]
    public class MembersControllerTest
    {

        private static List<Member> getTestMembers()
        {
            var memberA = new Member {
                memberId = 1,
                username = "memberA",
                name = "mem A",
                password = "p@ssw0rd",
                address = "123 Address St Atlanta, GA 30000",
                isLibrarian = 0,
                isBanned = 0
            };
            var memberB = new Member
            {
                memberId = 1,
                username = "memberB",
                name = "mem B",
                password = "hunter2",
                address = "321 Address St Atlanta, GA 30000",
                isLibrarian = 0,
                isBanned = 0
            };

            var testMembers = new List<Member> {memberA, memberB};

            return testMembers;
        }


        private static Mock<MemberContext> getMemberContext()
        {
            var memberContextMock = new Mock<MemberContext>();
            var members = getTestMembers().AsQueryable();
            var membersMock = new Mock<DbSet<Member>>();
            membersMock.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(members.Provider);
            membersMock.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(members.Expression);
            membersMock.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(members.ElementType);
            membersMock.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(members.GetEnumerator());

            memberContextMock.Setup(x => x.Members).Returns(membersMock.Object);




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
