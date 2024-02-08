using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            //var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=12345";
            //var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            // Criação da instância do DbContext com base nas configurações
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer("Persist Security Info=True; Data Source=localhost;Initial Catalog=dbAPI;Integrated Security=True; TrustServerCertificate = true;");

            return new MyContext(optionsBuilder.Options);
        }
    }
}
