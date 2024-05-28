using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class VeiculoViewModel
    {
                
        [Key]
        public int Id { get; set; }

        [Display(Name = "Código Renavam", Prompt = "00000000000")]
        [Required(ErrorMessage = "Código renavam é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O código renavam deve ter 11 caracteres.")]
        public string Renavam { get; set; } = null!;

        [Display(Name = "Placa", Prompt = "ABC1D23")]
        [RegularExpression(@"^[A-Z]{3}\d[A-Z]\d{2}$", ErrorMessage = "Placa inválida")]
        [Required(ErrorMessage = "Número da placa é obrigatório.")]
        [StringLength(7, ErrorMessage = "O número da placa deve estar no formato ABC1D23.")]
        public string Placa { get; set; } = null!;


        [Display(Name = "Data de Emissão")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [Required(ErrorMessage = "Data de emissão é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEmissao { get; set; }

        [Display(Name = "Órgão Expedidor", Prompt = "Órgão Expedidor")]
        [Required(ErrorMessage = "Órgão expedidor é obrigatório.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Órgão expedidor deve ter no mínimo 3 caracteres.")]
        public string Expedidor { get; set; } = null!;

        [Display(Name = "Estado", Prompt = "Estado")]
        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Escolha deve ter no mínimo 2 caracteres.")]
        public string Estado { get; set; } = null!;

        [Display(Name = "Código do motorista", Prompt = "Código do motorista")]
        [Required(ErrorMessage = "O Código do motorista é obrigatório.")]
        public int IdMotoristaPassageiro { get; set; }

    }
}
