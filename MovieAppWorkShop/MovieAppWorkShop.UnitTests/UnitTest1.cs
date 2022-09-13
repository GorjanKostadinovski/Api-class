using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieAppWorkShop.Contracts;
using MovieAppWorkShop.Contracts.Services;
using MovieAppWorkShop.Domain.Models;
using MovieAppWorkShop.Domain.Repositories;
using MovieAppWorkShop.Services.Mappers;
using System.Threading.Tasks;

namespace MovieAppWorkShop.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public  void UpdateMovieShouldUpdateExistingMovie()
        {
            // Arrange
            Movie updatedMovie = new Movie()
            {
                Title = "ad",
                Description = "a",
                Year = 1000
            };

            Movie movieToUpdate = new Movie()
            {
                Id = 2,
                Description = "b",
                Year = 2000,
                Title = "p"
                
            };

            // Act
            movieToUpdate.UpdateMovie(updatedMovie);

            // Assert
            Assert.AreEqual(movieToUpdate.Description, updatedMovie.Description);
            Assert.AreEqual(movieToUpdate.Title, updatedMovie.Title);
            Assert.AreEqual(movieToUpdate.Year, updatedMovie.Year);
            
        }
    }
}