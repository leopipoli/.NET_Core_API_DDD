namespace Domain.Dtos.User
{
    public class UserDto
    {
        [Required(ErrorMessage = "O nome é um campo obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O e-mail é um campo obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail está em um formato inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo {1} caracter.")]
        public string Email { get; set; }
    }
}
