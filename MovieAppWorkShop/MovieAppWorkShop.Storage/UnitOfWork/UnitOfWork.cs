using MovieAppWorkShop.Domain.UnitOfWork;
using MovieAppWorkShop.Storage.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWorkShop.Storage.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMoviesDbContext _moviesDbContext;

        public UnitOfWork(IMoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            if (_moviesDbContext.ChangeTracker.HasChanges())
            {
                return await _moviesDbContext.SaveChangesAsync();
            }

            return 0;
        }
    }
}
