using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [Display(Name = "E-mail", Prompt = "exemplo@dominio.com")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "O campo E-mail deve estar no formato exemplo@dominio.com.")]
        [EmailAddress(ErrorMessage = "O E-mail fornecido não é válido.")]
        [StringLength(50, ErrorMessage = "O campo E-mail deve ter no máximo {1} caracteres.")]
        public string Email { get; set; } = null!;

        [Display(Name = "Telefone", Prompt = "(00) 00000-0000")]
        [RegularExpression(@"^\(\d{2}\) \d{5}-\d{4}$", ErrorMessage = "O campo Telefone deve estar no formato (XX) XXXXX-XXXX.")]
        [StringLength(15)]
        public string Telefone { get; set; } = null!;

        [Display(Name = "Nome", Prompt = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 5 e 50 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido")]
        [StringLength(14)]
        [Display(Name = "CPF", Prompt = "000.000.000-00")]
        public string Cpf { get; set; } = null!;
    }
}
