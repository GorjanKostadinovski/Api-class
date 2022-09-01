using Microsoft.EntityFrameworkCore;
using MovieAppWorkShop.Domain.Models;
using MovieAppWorkShop.Domain.Repositories;
using MovieAppWorkShop.Storage.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWorkShop.Storage.Repositories
{
    public class UserRepository :RepositoryBase<User>,IUserRepository
    {

        public UserRepository(IMoviesDbContext dbContext) : base(dbContext)
        {

        }


        public async Task DeleteUserAsync(int id)
        {
            DeleteEntity(id);
        }

        public async Task<IReadOnlyList<User>> GetAllUsersAsync()
        {
            IQueryable<User> userQuery = GetAll();

            return await userQuery.ToArrayAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await GetById(id).SingleOrDefaultAsync();
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            return GetAll().SingleOrDefaultAsync(x => x.Username == username);
        }

        public void InsertUser(User newUser)
        {
            InsertEntity(newUser);
        }

        public async Task UpdateUserAsync(User existingUser)
        {
            UpdateEntity(existingUser);
        }
    }
}
