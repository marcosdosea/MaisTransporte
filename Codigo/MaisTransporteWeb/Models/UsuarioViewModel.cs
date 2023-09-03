using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "E-mail")]
        [Required]
        public string Email { get; set; } = null!;

        [Display(Name = "Telefone")]
        [Required]
        public string Telefone { get; set; } = null!;

        [Display(Name = "Nome")]
        [Required]
        public string Nome { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Cpf")]
        [Required]
        public string Cpf { get; set; } = null!;
    }
}
