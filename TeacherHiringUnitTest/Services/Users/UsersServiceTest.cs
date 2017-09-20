using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Users;
using Moq;
using DomainEntities.DataTransferObjects;
using DataAccess.Implementations;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Sqlite;
using System.Linq.Expressions;
using Services.Http.Implementations;
using Services.Http.Resolvers;
using System.Threading.Tasks;
using Services.Authentication.Implementations;
using Services.Authentication.Models;
using DataAccess.Sqlite.Models;

namespace TeacherHiringUnitTest.Services.Users
{
    [TestClass]
    public class UsersServiceTest
    {
        private EndpointResolver endpointResolverMock = new EndpointResolver("http://online.cuprum.com/webapixamarin/Api");

        [TestMethod]
        public void SaveUserData_WhenAllRequiredFieldsAreFilled_ReturnsUserSaved()
        {
            UserDto user = new UserDto
            {
                Name = "Test User",
                UserTypeId = 1,
                UserCreatedOn = DateTime.Parse("2017-09-12")
            };

            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IHttpClient> httpClientMock = new Mock<IHttpClient>();
            Mock<IRepository<User>> usersRepositoryMock = new Mock<IRepository<User>>();
            Mock<ITokenProvider> tokenProviderMock = new Mock<ITokenProvider>();

            unitOfWorkMock.Setup(u => u.UserDataRepository).Returns(usersRepositoryMock.Object);

            usersRepositoryMock.Setup(repository => repository.Add(It.IsAny<User>())).Returns(123);
            usersRepositoryMock.Setup(repository => repository.FindBy(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User>().AsQueryable());

            tokenProviderMock.Setup(tokenProvider => tokenProvider.GetToken()).Returns(new Token { AccessValue = "AnyToken" });
            httpClientMock.Setup(client => client.GetTokenProvider()).Returns(tokenProviderMock.Object);

            UsersService usersService = new UsersService(unitOfWorkMock.Object, httpClientMock.Object, endpointResolverMock);
            UserDto savedUser = usersService.SaveUserData(user);
            
            Assert.AreEqual(123, savedUser.UserId);
            Assert.AreEqual("Test User", savedUser.Name);
            Assert.AreEqual(1, savedUser.UserTypeId);
            Assert.AreEqual(DateTime.Parse("2017-09-12"), savedUser.UserCreatedOn);

            usersRepositoryMock.Verify(repository => repository.Add(It.IsAny<User>()));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The argument \"userData\" is not valid")]
        public void SaveUserData_WhenRequiredFieldIsNotFilled_ThrowException()
        {
            UserDto user = new UserDto { };

            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IHttpClient> httpClientMock = new Mock<IHttpClient>();
            Mock<IRepository<User>> usersRepositoryMock = new Mock<IRepository<User>>();

            unitOfWorkMock.Setup(u => u.UserDataRepository).Returns(usersRepositoryMock.Object);
            usersRepositoryMock.Setup(repository => repository.Add(It.IsAny<User>())).Returns(123);
            usersRepositoryMock.Setup(repository => repository.FindBy(It.IsAny<Expression<Func<User, bool>>>())).Returns(createSavedUserMockList());

            UsersService usersService = new UsersService(unitOfWorkMock.Object, httpClientMock.Object, endpointResolverMock);
            UserDto savedUser = usersService.SaveUserData(user);
        }

        [TestMethod]
        public void SaveUserData_WhenUserExists_UpdateUser()
        {
            UserDto user = new UserDto
            {
                UserId = 123,
                Name = "Test User2",
                UserTypeId = 1,
                UserCreatedOn = DateTime.Parse("2017-09-12")
            };

            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IHttpClient> httpClientMock = new Mock<IHttpClient>();
            Mock<IRepository<User>> usersRepositoryMock = new Mock<IRepository<User>>();
            Mock<ITokenProvider> tokenProviderMock = new Mock<ITokenProvider>();

            unitOfWorkMock.Setup(u => u.UserDataRepository).Returns(usersRepositoryMock.Object);

            usersRepositoryMock.Setup(repository => repository.Update(It.IsAny<User>())).Returns(123);
            usersRepositoryMock.Setup(repository => repository.FindBy(It.IsAny<Expression<Func<User, bool>>>())).Returns(createSavedUserMockList());

            tokenProviderMock.Setup(tokenProvider => tokenProvider.GetToken()).Returns(new Token { AccessValue = "AnyToken" });
            httpClientMock.Setup(client => client.GetTokenProvider()).Returns(tokenProviderMock.Object);

            UsersService usersService = new UsersService(unitOfWorkMock.Object, httpClientMock.Object, endpointResolverMock);
            UserDto savedUser = usersService.SaveUserData(user);

            Assert.AreEqual(123, savedUser.UserId);
            Assert.AreEqual("Test User2", savedUser.Name);
            Assert.AreEqual(1, savedUser.UserTypeId);
            Assert.AreEqual(DateTime.Parse("2017-09-12"), savedUser.UserCreatedOn);

            usersRepositoryMock.Verify(repository => repository.Update(It.IsAny<User>()));
        }

        private IQueryable<User> createSavedUserMockList()
        {
            User savedUserMock = new User
            {
                UserId = 123,
                Name = "Test User",
                UserCreatedOn = DateTime.Parse("2017-09-12"),
                UserTypeId = 1
            };

            List<User> list = new List<User>();
            list.Add(savedUserMock);

            return list.AsQueryable();
        }
    }
}
