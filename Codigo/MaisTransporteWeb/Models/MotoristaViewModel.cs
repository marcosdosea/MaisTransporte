using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class MotoristaViewModel
    {
        [Display(Name = "Nº do Documento")]
        [Required(ErrorMessage = "Número do documento é obrigatório.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Número do documento deve ter entre 5 e 15 caracteres.")]
        public string NumeroDocumento { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Data de Emissão")]
        [Required(ErrorMessage = "A data de Emissão é obrigatória.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEmissao { get; set; }
      
        [Display(Name = "Órgão Expeditor")]
        [Required(ErrorMessage = "O nome do órgão expeditor é obrigatório.")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Órgão Expeditor deve ter entre 2 e 50 caracteres.")]
        public string OrgaoExpeditor { get; set; } = null!;

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O nome do Estado é obrigatório.")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "Estado deve ter entre 3 e 50 caracteres.")]
        public string Estado { get; set; } = null!;
    }
}
