using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class ViagemViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Título", Prompt = "Título")]
        [Required(ErrorMessage = "Título da viagem é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Título da viagem deve ter entre 5 e 50 caracteres.")]
        public string Titulo { get; set; } = null!;

        [Display(Name = "Local de origem", Prompt = "Local de origem" )]
        [Required(ErrorMessage = "Local de origem da viagem é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Local de origem deve ter entre 5 e 50 caracteres.")]
        public string LocalOrigem { get; set; } = null!;

        [Display(Name = "Destino", Prompt = "Local de destino")]
        [Required(ErrorMessage = "Local de destino da viagem é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Local de destino deve ter entre 5 e 50 caracteres.")]
        public string LocalDestino { get; set; } = null!;

        [Display(Name = "Valor da passagem", Prompt = "Valor da passagem")]
        [Required(ErrorMessage = "Valor da passagem é obrigatório.")]
        public float ValorPassagem { get; set; }

        [Display(Name = "Total de vagas", Prompt = "Total de vagas" )]
        [Required(ErrorMessage = "Total de vagas da viagem é obrigatório.")]
        public int TotalVagas { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Data válida requerida.")]
        [Display(Name = "Data e Horário de partida")]
        [Required(ErrorMessage = "A data e o horário de partida são obrigatórios.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPartida { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Data válida requerida")]
        [Display(Name = "Data e Horário de volta")]
        [Required(ErrorMessage = "A data e o horário de volta são obrigatórios.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataChegada { get; set; }

        [Display(Name = "Descrição", Prompt = "Descrição")]
        [Required(ErrorMessage = "Descrição da viagem é obrigatória.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 100 caracteres")]
        public string Descricao { get; set; } = null!;

        [Display(Name = "Código do Motorista", Prompt = "Código do motorista" )]
        [Required(ErrorMessage = "Código do motorista é obrigatório.")]
        public int IdMotorista { get; set; }
    }
}
