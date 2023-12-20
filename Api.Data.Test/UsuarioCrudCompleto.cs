using Data.Context;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
        }

        [Fact(DisplayName = "CRUD Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_Crud_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity()
                {
                    Email = "teste@mail.com",
                    Name = "Teste"
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal("teste@mail.com", _registroCriado.Email);
                Assert.Equal("Teste", _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);
            };
        }
    }
}
