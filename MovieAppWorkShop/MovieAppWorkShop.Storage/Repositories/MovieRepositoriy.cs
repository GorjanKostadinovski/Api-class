using Microsoft.EntityFrameworkCore;
using MovieAppWorkShop.Domain.Repositories;
using MovieAppWorkShop.Domain.Models;
using MovieAppWorkShop.Storage.Database;


namespace MovieAppWorkShop.Storage.Repositories
{
    public class MovieRepositoriy : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepositoriy(IMoviesDbContext moviesDbContext) : base(moviesDbContext)
        {

        }

        public void DeleteAsync(int id)
        {
            DeleteEntity(id);
        }

        public async Task<IReadOnlyList<Movie>> GetAllMoviesAsync()
        {
            IQueryable<Movie> noteQuery = GetAll();

            return await noteQuery.ToArrayAsync();
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await GetById(id).SingleOrDefaultAsync();
        }

        public void InsertAsync(Movie newMovies)
        {
             InsertEntity(newMovies);
        }

        public void UpdateAsync(Movie existingMovie)
        {
            UpdateEntity(existingMovie);
        }

    }
}
