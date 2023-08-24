using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class SugerirViagemViewModel
    {
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

        [Display(Name = "Data de partida")]
        [Required]
        public DateTime DataPartida { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Data de volta")]
        [Required]
        public DateTime DataChegada { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Horário 1")]
        [Required]
        public TimeSpan HorarioPartida { get; set; }

        [Display(Name = "Horário 2")]
        [Required]
        public TimeSpan HorarioChegada { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; } = null!;

        [Display(Name = "Status")]
        [Required]
        public string Status { get; set; } = null!;
    }
}

