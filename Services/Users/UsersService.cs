using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities.DataTransferObjects;
using DataAccess.Implementations;
using DataAccess.Sqlite;
using Services.Http.Implementations;
using Services.Http.Resolvers;
using Services.Authentication.Implementations;
using DataAccess.Sqlite.Models;

namespace Services.Users
{
    public class UsersService : IUsersService
    {
        private IUnitOfWork unitOfWork;
        private IHttpClient httpClient;
        private EndpointResolver endpointResolver;

        public UsersService(IUnitOfWork unitOfWork, IHttpClient httpClient, EndpointResolver endpointResolver)
        {
            this.unitOfWork = unitOfWork;
            this.httpClient = httpClient;
            this.endpointResolver = endpointResolver;
        }

        public async Task<UserDto> GetUserData()
        {
            ITokenProvider tokenProvider = httpClient.GetTokenProvider();

            string endpoint = endpointResolver.ResolveUrl("GetDataPerson", "Usuario") + "?token=" + tokenProvider.GetToken().AccessValue;
            IHttpClientResponse clientResponse = await httpClient.Get(endpoint);

            return clientResponse.GetContentAsObject<UserDto>();
        }

        public UserDto SaveUserData(UserDto user)
        {
            if (!isUserValid(user))
                throw new ArgumentException("The argument \"user\" is not valid");

            User userModel = convertUserDtoToUserModel(user);

            if (userExists(user))
                unitOfWork.UserDataRepository.Update(userModel);
            else
                userModel.UserId = (int)unitOfWork.UserDataRepository.Add(userModel);

            return convertUserModelToUserDto(userModel);
        }

        private bool isUserValid(UserDto user)
        {
            return !string.IsNullOrEmpty(user.Name) && user.UserTypeId != 0;
        }

        private User convertUserDtoToUserModel(UserDto dto)
        {
            ITokenProvider tokenProvider = httpClient.GetTokenProvider();

            return new User
            {
                UserId = dto.UserId,
                UserTypeId = dto.UserTypeId,
                Name = dto.Name,
                UserCreatedOn = dto.UserCreatedOn,
                Token = tokenProvider.GetToken().AccessValue
            };
        }

        private bool userExists(UserDto user)
        {
            return unitOfWork.UserDataRepository.FindBy(x => x.UserId == user.UserId).FirstOrDefault() != null;
        }

        private UserDto convertUserModelToUserDto(User model)
        {
            return new UserDto
            {
                UserId = model.UserId,
                UserTypeId = model.UserTypeId,
                Name = model.Name,
                UserCreatedOn = model.UserCreatedOn,
                Token = model.Token
            };
        }
    }
}
