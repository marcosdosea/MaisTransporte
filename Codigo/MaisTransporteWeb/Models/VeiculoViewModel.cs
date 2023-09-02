using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class VeiculoViewModel
    {

        [Display(Name = "Código")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Renavam")]
        [Required(ErrorMessage = "Código renavam é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O código renavam deve ter 11 caracteres.")]
        public string Renavan { get; set; }

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Número da placa é obrigatório.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "O número da placa deve ter 7 caracteres.")]
        public string Placa { get; set; }

        [Display(Name = "DataEmissao")]
        [Required(ErrorMessage = "Data de emissão é obrigatório.")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEmissao { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Expedidor")]
        [Required(ErrorMessage = "Órgão expedidor é obrigatório.")]
        [StringLength(3, MinimumLength = 5, ErrorMessage = "Órgão expedidor deve ter entre 3 e 5 caracteres.")]
        public string Expedidor { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Escolha um Estado.")]
        public string Estado { get; set; }


    }
}
