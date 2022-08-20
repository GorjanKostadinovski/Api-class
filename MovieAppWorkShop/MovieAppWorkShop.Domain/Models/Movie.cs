using Microsoft.EntityFrameworkCore;
using MovieAppWorkShop.Domain.Models;
using MovieAppWorkShop.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAppWorkShop.Domain.Models
{
    public class Movie:BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public MovieGenre Genre { get; set; }

        public Movie()
        {

        }

    }




}

