using System;
using System.ComponentModel.DataAnnotations;

namespace AlunoApi.Models
{
    public class Aluno
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo CPF deve ter 11 caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Nascimento é obrigatório")]
        public DateTime Nascimento { get; set; }
    }
}
