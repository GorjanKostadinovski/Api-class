using MovieAppWorkShop.Domain.Models;
using MovieAppWorkShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWorkShop.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<IReadOnlyList<Movie>> GetAllMoviesAsync();

        Task< Movie> GetMovieAsync(int id);

        
        void InsertAsync(Movie newMovie);
        void DeleteAsync(int id);
        void  UpdateAsync(Movie movie);
    }
}
