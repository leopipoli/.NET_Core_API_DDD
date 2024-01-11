using Domain.Interfaces.Services.User;
using Moq;
using Service.Test.Usuario;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoUpdate : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o método Update.")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Post(userCreateDto))
                        .ReturnsAsync(userCreateResultDto);
            _service = _serviceMock.Object;

            var result = await _service.Post(userCreateDto);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Put(userUpdateDto))
                        .ReturnsAsync(userUpdateResultDto);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(userUpdateDto);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);
        }
    }
}
