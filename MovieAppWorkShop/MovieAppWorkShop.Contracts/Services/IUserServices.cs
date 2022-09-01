using MovieAppWorkShop.Contracts.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWorkShop.Contracts.Services
{
    public interface IUserServices
    {
        Task RegisterUser(RegisterUserDto registerUserDto);

        Task<string> LoginUser(LoginUserDto loginUserDto);
    }
}
