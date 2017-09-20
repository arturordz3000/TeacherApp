using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Http.Implementations;
using Moq;
using DataAccess.Sqlite;
using DomainEntities.DataTransferObjects;
using Services.Users;
using Services.Http.Resolvers;
using Services.Authentication.Models;
using Services.Authentication.Implementations;
using System.Threading.Tasks;
using Services.Http.Clients;
using DataAccess.Implementations;
using DataAccess.Sqlite.Models;
using System.Linq;

namespace TeacherHiringIntegrationTest.Users
{
    [TestClass]
    public class UsersServiceTest
    {
        private Mock<ITokenProvider> mockTokenProvider;
        private Mock<IUnitOfWork> mockUnitOfWork;
        private Mock<IHttpClient> mockHttpClient;
        private Token mockToken;
        private string baseUrl = "http://online.cuprum.com/webapixamarin/Api";

        public UsersServiceTest()
        {
            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockToken = new Token { AccessValue = "BQkGz1w+ERCD/dhqYSNQaitXWGiDuWtgzfMxmdPUre2tI+678Z9rGADPy3b6QkIYA1pPTL2Ln3OUkGtU772aTA==", ExpirySeconds = 43800 };
            mockTokenProvider = new Mock<ITokenProvider>();
            mockTokenProvider.Setup(provider => provider.GetToken()).Returns(mockToken);
            mockHttpClient = new Mock<IHttpClient>();
            mockHttpClient.Setup(client => client.GetTokenProvider()).Returns(mockTokenProvider.Object);
        }

        [TestMethod]
        public async Task GetUserData_WithValidToken_ReturnUserData()
        {
            RestClient client = new RestClient(mockTokenProvider.Object);
            UsersService usersService = new UsersService(mockUnitOfWork.Object, client, new EndpointResolver(baseUrl));

            UserDto userData = await usersService.GetUserData();

            Assert.AreEqual(16, userData.UserId);
            Assert.AreEqual("Arturo Rodriguez", userData.Name);
            Assert.AreEqual(2, userData.UserTypeId);
            Assert.AreEqual(DateTime.Parse("2017-09-01T13:00:30.377"), userData.UserCreatedOn);
        }

        [TestMethod]
        public void SaveUserData_WithNonExistingUser_UserSaved()
        {
            IContext context = new SqliteContext();
            IUnitOfWork unitOfWork = new SqliteUnitOfWork(context);

            unitOfWork.UserDataRepository.Delete(new User { UserId = 1 });

            UsersService usersService = new UsersService(unitOfWork, mockHttpClient.Object, new EndpointResolver("someURL"));
            UserDto user = new UserDto
            {
                Name = "Test User",
                UserId = 1,
                UserTypeId = 1,
                Token = "BQkGz1w+ERCD/dhqYSNQaitXWGiDuWtgzfMxmdPUre2tI+678Z9rGADPy3b6QkIYA1pPTL2Ln3OUkGtU772aTA==",
                UserCreatedOn = DateTime.Parse("2017-09-13")
            };

            UserDto savedUser = usersService.SaveUserData(user);
            User userInDatabase = unitOfWork.UserDataRepository.FindBy(x => x.UserId == savedUser.UserId).FirstOrDefault();

            Assert.AreEqual(1, userInDatabase.UserId);
            Assert.AreEqual(1, userInDatabase.UserTypeId);
            Assert.AreEqual("Test User", userInDatabase.Name);
            Assert.AreEqual("BQkGz1w+ERCD/dhqYSNQaitXWGiDuWtgzfMxmdPUre2tI+678Z9rGADPy3b6QkIYA1pPTL2Ln3OUkGtU772aTA==", userInDatabase.Token);
            Assert.AreEqual(DateTime.Parse("2017-09-13"), userInDatabase.UserCreatedOn);
        }

        [TestMethod]
        public void SaveUserData_WithExistingUser_UserUpdated()
        {
            IContext context = new SqliteContext();
            IUnitOfWork unitOfWork = new SqliteUnitOfWork(context);

            unitOfWork.UserDataRepository.Delete(new User { UserId = 1 });

            UsersService usersService = new UsersService(unitOfWork, mockHttpClient.Object, new EndpointResolver("someURL"));
            UserDto user = new UserDto
            {
                Name = "Test User",
                UserId = 1,
                UserTypeId = 1,
                Token = "BQkGz1w+ERCD/dhqYSNQaitXWGiDuWtgzfMxmdPUre2tI+678Z9rGADPy3b6QkIYA1pPTL2Ln3OUkGtU772aTA==",
                UserCreatedOn = DateTime.Parse("2017-09-13")
            };

            UserDto savedUser = usersService.SaveUserData(user);
            user.Name = "Test User Updated";
            savedUser = usersService.SaveUserData(user);

            User userInDatabase = unitOfWork.UserDataRepository.FindBy(x => x.UserId == savedUser.UserId).FirstOrDefault();

            Assert.AreEqual(1, userInDatabase.UserId);
            Assert.AreEqual(1, userInDatabase.UserTypeId);
            Assert.AreEqual("Test User Updated", userInDatabase.Name);
            Assert.AreEqual("BQkGz1w+ERCD/dhqYSNQaitXWGiDuWtgzfMxmdPUre2tI+678Z9rGADPy3b6QkIYA1pPTL2Ln3OUkGtU772aTA==", userInDatabase.Token);
            Assert.AreEqual(DateTime.Parse("2017-09-13"), userInDatabase.UserCreatedOn);
        }
    }
}
