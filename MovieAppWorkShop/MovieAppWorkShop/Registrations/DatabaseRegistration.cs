using Microsoft.EntityFrameworkCore;
using MovieAppWorkShop.Database;

namespace MovieAppWorkShop.Registrations
{
    public static class DatabaseRegistration
    {

        public static IServiceCollection RegisterDatabase(this IServiceCollection serviceCollection,
                                                          string connectionString)
        {
            serviceCollection.AddDbContext<MoviesDbContext>(actions =>
            {
                actions.UseSqlServer(connectionString);
            });

            return serviceCollection;
        }
    }
}
