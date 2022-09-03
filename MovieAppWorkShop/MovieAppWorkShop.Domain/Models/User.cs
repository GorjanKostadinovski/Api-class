using MovieAppWorkShop.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWorkShop.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public Role Role { get; set; }

        public User()
        {

        }
    }
}
