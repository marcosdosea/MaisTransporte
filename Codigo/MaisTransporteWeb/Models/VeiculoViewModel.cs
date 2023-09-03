using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class VeiculoViewModel
    {
                
        [Key]
        public int Id { get; set; }

        [Display(Name = "Código Renavam")]
        [Required(ErrorMessage = "Código renavam é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O código renavam deve ter 11 caracteres.")]
        public string Renavam { get; set; } = null!;

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Número da placa é obrigatório.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "O número da placa deve ter 7 caracteres.")]
        public string Placa { get; set; } = null!;


        [Display(Name = "Data de Emissão")]
        [DataType(DataType.DateTime, ErrorMessage = "Data válida requerida")]
        [Required(ErrorMessage = "Data de emissão é obrigatório.")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEmissao { get; set; }

        [Display(Name = "Órgão Expedidor")]
        [Required(ErrorMessage = "Órgão expedidor é obrigatório.")]
        [StringLength(3, ErrorMessage = "Órgão expedidor deve ter no mínimo 3 caracteres.")]
        public string Expedidor { get; set; } = null!;

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Escolha um Estado.")]
        public string Estado { get; set; } = null!;

        [Display(Name= "Motorista")]
        [Required(ErrorMessage = "O campo Motorista é obrigatório.")]
        public int IdMotoristaPassageiro { get; set; }

    }
}
