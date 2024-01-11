using Domain.Dtos.User;

namespace Service.Test.Usuario
{
    public class UsuarioTestes
    {
        public static string NomeUsuario { get; set; }
        public static string EmailUsuario { get; set; }
        public static string NomeUsuarioAlterado { get; set; }
        public static string EmailUsuarioAlterado { get; set; }
        public static Guid IdUsuario { get; set; }

        public UserDto userDto;
        public UserCreateDto userCreateDto;
        public UserCreateResultDto userCreateResultDto;
        public UserUpdateDto userUpdateDto;
        public UserUpdateResultDto userUpdateResultDto;

        public List<UserDto> listaUserDto = new List<UserDto>();

        public UsuarioTestes()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                };
                listaUserDto.Add(dto);
            }

            userDto = new UserDto()
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario,
            };

            userCreateDto = new UserCreateDto()
            {
                Name = NomeUsuario,
                Email = EmailUsuario,
            };

            userCreateResultDto = new UserCreateResultDto()
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario,
                CreateAt = DateTime.UtcNow,
            };

            userUpdateDto = new UserUpdateDto()
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
            };

            userUpdateResultDto = new UserUpdateResultDto()
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                UpdateAt = DateTime.UtcNow,
            };
        }
    }
}
