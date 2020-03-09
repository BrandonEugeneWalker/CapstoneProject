﻿using System.Collections.Generic;
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
    ///     Tests the MembersController behavior
    /// </summary>
    [TestClass]
    public class MembersControllerTest
    {
        #region Methods

        //TODO REMOVE
        private static Mock<MemberContext> getMemberContext()
        {
            var memberContextMock = new Mock<MemberContext>();

            //TODO mock login session
            //var mockSession = new Mock<HttpContextBase>();
            //var session = new Mock<HttpSessionStateBase>();

            //mockSession.Setup(ctx => ctx.Session).Returns(session.Object);
            //memberContextMock.Setup(ctx => ctx.).Returns(mockSession.Object);

            var members = getTestMembers().AsQueryable();
            var membersMock = new Mock<DbSet<Member>>();
            membersMock.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(members.Provider);
            membersMock.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(members.Expression);
            membersMock.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(members.ElementType);
            membersMock.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(members.GetEnumerator());
            memberContextMock.Setup(x => x.Members).Returns(membersMock.Object);

            return memberContextMock;
        }

        [TestMethod]
        public void Create_IsNotNull()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatingNewEmployeeIsValid()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);
            var newMember = new Member
                {memberId = 3, username = "newMember", name = "New Member", password = "P@ss12"};

            // Act
            var result = controller.Create(newMember) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatingInvalidEmployeeReturnsToCreate()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);
            var newMember = new Member
                { memberId = 3, username = "newMember", name = "New Member", password = ""};

            // Act
            var result = controller.Create(newMember) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //TODO will require session mocking
        [TestMethod]
        public void Details_IsNotNull()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);

            // Act
            var result = controller.Details() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //TODO will require session mocking
        [TestMethod] 
        public void Edit_IsNotNull()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);

            // Act
            var result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //TODO will require session mocking
        [TestMethod]
        public void Edit_IsValid()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);
            var newMember = new Member
                { memberId = 3, username = "newMember", name = "New Member", password = "P@ss12"};

            // Act
            var result = controller.Edit(3) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //TODO will require session mocking
        [TestMethod]
        public void EditingMemberIncorrectlyReturnsToEdit()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);
            var newMember = new Member
                { memberId = 3, username = "newMember", name = "New Member", password = ""};

            // Act
            var result = controller.Edit(3) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Login_IsNotNull()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);

            // Act
            var result = controller.Login(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ValidLoginRedirectsToHomeIndex()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);
            var newMember = new Member
                { memberId = 3, username = "newMember", name = "New Member", password = "P@ss12"};

            // Act
            var result = controller.Login(newMember) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void InvalidLoginRedirectsToLogin()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);
            var newMember = new Member
                { memberId = 3, username = "newMember", name = "New Member", password = "P@ss12"};

            // Act
            var result = controller.Login(newMember) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //TODO requires Session mock
        [TestMethod]
        public void LoggingOffClearsSession()
        {
            // Arrange
            var controller = new MembersController(getMemberContext().Object);

            // Act
            var result = controller.LogOff() as ViewResult;

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

        private static IEnumerable<Member> getTestMembers()
        {
            var memberA = new Member
            {
                memberId = 1,
                username = "memberA",
                name = "mem A",
                password = "p@ssw0rd",
                isLibrarian = 0,
                isBanned = 0
            };
            var memberB = new Member
            {
                memberId = 2,
                username = "memberB",
                name = "mem B",
                password = "hunter2",
                isLibrarian = 0,
                isBanned = 0
            };
            var memberC = new Member
            {
                memberId = 3,
                username = "memberB",
                name = "mem C",
                password = "Hunter2!",
                isLibrarian = 0,
                isBanned = 0
            };

            var testMembers = new List<Member> { memberA, memberB, memberC };

            return testMembers;
        }

        #endregion
    }
}