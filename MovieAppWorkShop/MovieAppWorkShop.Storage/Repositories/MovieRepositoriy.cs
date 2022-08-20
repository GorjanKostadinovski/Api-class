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

        public async Task Delete(int id)
        {
            DeleteEntity(id);
        }

        public async Task<IReadOnlyList<Movie>> GetAllNotesAsync()
        {
            IQueryable<Movie> noteQuery = GetAll();

            return await noteQuery.ToArrayAsync();
        }

        public async Task<Movie> GetNote(int id)
        {
            return await GetById(id).SingleOrDefaultAsync();
        }

        public async Task Insert(Movie newMovies)
        {
            InsertEntity(newMovies);
        }

        public async Task UpdateNoteAsync(Movie existingNote)
        {
            UpdateEntity(existingNote);
        }

    }
}
