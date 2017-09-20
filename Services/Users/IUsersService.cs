using DomainEntities.DataTransferObjects;
using Services.Authentication.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public interface IUsersService
    {
        Task<UserDto> GetUserData();
        UserDto SaveUserData(UserDto user);
    }
}
