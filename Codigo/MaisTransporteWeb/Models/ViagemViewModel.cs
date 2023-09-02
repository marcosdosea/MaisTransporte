using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class ViagemViewModel
    {
        [Display(Name = "Código")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required]
        public string Titulo { get; set; } = null!;

        [Display(Name = "Local de origem")]
        [Required]
        public string LocalOrigem { get; set; } = null!;

        [Display(Name = "Destino")]
        [Required]
        public string LocalDestino { get; set; } = null!;

        [Display(Name = "Valor da passagem")]
        [Required]
        public float ValorPassagem { get; set; }

        [Display(Name = "Total de vagas")]
        [Required]
        public int TotalVagas { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data e Horário de partida")]
        [Required]
        public DateTime DataPartida { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Data e Horário de volta")]
        [Required]
        public DateTime DataChegada { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; } = null!;

        [Display(Name = "Código do Motorista")]
        [Required]
        public int IdMotorista { get; set; }
    }
}