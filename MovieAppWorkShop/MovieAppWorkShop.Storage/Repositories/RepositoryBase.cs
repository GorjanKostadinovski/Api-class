using MovieAppWorkShop.Database;
using MovieAppWorkShop.Domain.Models;
using MovieAppWorkShop.Models;
using MovieAppWorkShop.Storage.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWorkShop.Storage.Repositories
{
    public abstract class RepositoryBase<T> where T : BaseEntity
    {
        protected readonly IMoviesDbContext _movieDbContext;

        protected RepositoryBase(IMoviesDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        protected IQueryable<T> GetById(int id)
        {
            return GetAll().Where(x => x.Id == id);
        }

        protected IQueryable<T> GetAll()
        {
            return _movieDbContext.Set<T>();
        }

        protected void InsertEntity(T item)
        {
            _movieDbContext.Set<T>().Add(item);
        }

        protected void DeleteEntity(int id)
        {
            _movieDbContext.Set<T>().Remove(GetById(id).SingleOrDefault());
        }
    }
}
