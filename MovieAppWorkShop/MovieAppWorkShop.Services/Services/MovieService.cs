using MovieAppWorkShop.Contracts;
using MovieAppWorkShop.Contracts.Services;
using MovieAppWorkShop.Domain.Models;
using MovieAppWorkShop.Domain.Repositories;
using MovieAppWorkShop.Domain.UnitOfWork;
using MovieAppWorkShop.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWorkShop.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateMoviesAsync(GetMovieByIdDTO newMovie)
        {
            Movie movie = newMovie.ToMovie();
             _movieRepository.InsertAsync(movie);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(int id, GetMovieByIdDTO movieToUpdate)
        {
            Movie movie = await _movieRepository.GetMovieAsync(id);
            movie.UpdateMovie(movieToUpdate.ToMovie());


             _movieRepository.UpdateAsync(movie);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
             _movieRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<GetMovieByIdDTO>> GetAllMoviesAsync()
        {
            IReadOnlyList<Movie> movies = await _movieRepository.GetAllMoviesAsync();
            return movies.Select(x => x.ToMovieDto()).ToArray();
        }

        public async Task<GetMovieByIdDTO> GetMoviesAsync(int id)
        {
            Movie movie = await _movieRepository.GetMovieAsync(id);

            if(movie == null)
            {
                return null;
            }

            return movie.ToMovieDto();
        }

    }
}
