using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class MotoristaViewModel
    {
        [Display(Name = "Nº do Documento", Prompt = "00000000000")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Nº do documento inválido")]
        [Required(ErrorMessage = "Número do documento é obrigatório.")]
        [StringLength(15, ErrorMessage = "Número do documento tem 11 caracteres.")]
        public string NumeroDocumento { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Data de Emissão")]
        [Required(ErrorMessage = "A data de Emissão é obrigatória.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEmissao { get; set; }
      
        [Display(Name = "Órgão Expedidor", Prompt = "Órgão expedidor")]
        [Required(ErrorMessage = "O nome do órgão expedidor é obrigatório.")]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "Órgão Expedidor deve ter 3.")]
        public string OrgaoExpeditor { get; set; } = null!;

        [Display(Name = "Estado", Prompt = "Estado")]
        [Required(ErrorMessage = "O Estado é obrigatório.")]
        [StringLength(2, ErrorMessage = "Estado deve ter 2 caracteres.")]
        public string Estado { get; set; } = null!;
    }
}
