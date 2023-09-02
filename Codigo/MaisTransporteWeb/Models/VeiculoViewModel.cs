using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class VeiculoViewModel
    {

        [Display(Name = "Código")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Renavan")]
        [Required]
        public string Renavan { get; set; }

        [Display(Name = "Placa")]
        [Required]
        public string Placa { get; set; }

        [Display(Name = "DataEmissao")]
        [Required]
        public DateTime DataEmissao { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Expedidor")]
        [Required]
        public string Expedidor { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public string Estado { get; set; }


    }
}
