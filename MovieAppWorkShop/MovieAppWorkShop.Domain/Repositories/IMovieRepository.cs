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
        Task<IReadOnlyList<Movie>> GetAllPizzasAsync();

        Movie GetPizza(int id);

        
        void Insert(Movie newMovie);
        void Delete(int id);
        void Update(Movie movie);
    }
}
