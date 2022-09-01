using MovieAppWorkShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWorkShop.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IReadOnlyList<User>> GetAllUsersAsync();

        Task<User> GetUserAsync(int id);

        void InsertUser(User newUser);

        Task UpdateUserAsync(User existingUser);

        Task DeleteUserAsync(int id);

        Task<User> GetUserByUsernameAsync(string username);
    }
}
