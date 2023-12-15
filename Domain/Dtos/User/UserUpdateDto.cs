using System.ComponentModel.DataAnnotations;
using System;

namespace Domain.Dtos.User
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "Id é um campo obrigatório.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é um campo obrigatório.")]
        [StringLength(60, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O e-mail é um campo obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail está em um formato inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
    }
}
