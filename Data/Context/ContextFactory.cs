using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            ////Usado para Criar as Migrações
            ////var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=12345";
            //var connectionString = Configuration.GetConnectionString("DefaultConnection");
            //var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            ////optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            //optionsBuilder.UseSqlServer(connectionString);
            //return new MyContext(optionsBuilder.Options);

            // Criação da instância do DbContext com base nas configurações
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new MyContext(optionsBuilder.Options);
        }
    }
}
