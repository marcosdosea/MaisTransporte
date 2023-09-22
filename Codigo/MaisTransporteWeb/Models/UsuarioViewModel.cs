using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "E-mail deve ter entre 10 e 50 caracteres")]
        public string Email { get; set; } = null!;

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "Telefone deve ter entre 11 e 15 caracteres")]
        public string Telefone { get; set; } = null!;

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 5 e 50 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "CPF deve ter entre 11 e 15 caracteres")]
        public string Cpf { get; set; } = null!;
    }
}
