using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class MotoristaViewModel
    {
        [Display(Name = "Nº do Documento")]
        [Required]
        public string NumeroDocumento { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Data de Emissão")]
        [Required]
        public DateTime DataEmissao { get; set; }

        [Display(Name = "Órgão Expeditor")]
        [Required]
        public string OrgaoExpeditor { get; set; } = null!;

        [Display(Name = "Estado")]
        [Required]
        public string Estado { get; set; } = null!;
    }
}
