using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWorkShop.Contracts.Services
{
    public interface IMovieService
    {
        Task<IReadOnlyList<GetMovieByIdDTO>> GetAllMoviesAsync();

        Task<GetMovieByIdDTO> GetMoviesAsync(int id);

        Task CreateMoviesAsync(GetMovieByIdDTO newNote);

        Task UpdateMovieAsync(int id, GetMovieByIdDTO existingNote);

        Task DeleteMovieAsync(int id);
    }
}
