using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
        }
    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider serviceProvider { get; private set; }

        public DbTeste()
        {
            var connectionString = $"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=root;Password=12345";
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(x =>
                x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
                //x.UseSqlServer($"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=root;Password=12345"), 
                    ServiceLifetime.Transient
            );

            serviceProvider = serviceCollection.BuildServiceProvider();
            using (var context = serviceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = serviceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }

}