using Data.Context;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            var connectionString = "server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=12345";
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }
    }
}
