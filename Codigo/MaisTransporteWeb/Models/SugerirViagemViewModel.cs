using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class SugerirViagemViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da viagem é obrigatório."]
        public int Id { get; set; }

        [Display(Name = "Código do Passageiro")]
        [Required(ErrorMessage = "Código do passageiro é obrigatório."]
        public int IdPassageiro { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Título da viagem é obrigatório."]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Título da viagem deve ter entre 5 e 50 caracteres")]
        public string Titulo { get; set; } = null!;

        [Display(Name = "Local de origem")]
        [Required(ErrorMessage = "Local de origem da viagem é obrigatório."]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Local de origem deve ter entre 5 e 50 caracteres")]
        public string LocalOrigem { get; set; } = null!;

        [Display(Name = "Destino")]
        [Required(ErrorMessage = "Local de destino da viagem é obrigatório."]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O destino deve ter entre 5 e 50 caracteres")]
        public string LocalDestino { get; set; } = null!;

        [Display(Name = "Valor da passagem")]
        [Required(ErrorMessage = "Valor da passagem é obrigatório."]
        public float ValorPassagem { get; set; }

        [Display(Name = "Total de vagas")]
        [Required(ErrorMessage = "Total de vagas da viagem é obrigatório."]
        public int TotalVagas { get; set; }

        [Display(Name = "Data e Horário de partida")]
        [DataType(DataType.DateTime, ErrorMessage ="Data válida requerida"))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPartida { get; set; }

        [Display(Name = "Data e Horário de volta")]
        [DataType(DataType.DateTime, ErrorMessage ="Data válida requerida"))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataChegada { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição da viagem é obrigatória."]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 100 caracteres")]
        public string Descricao { get; set; } = null!;

        [Display(Name = "Visibilidade")]
        [Required(ErrorMessage = "Visibilidade da viagem é obrigatória."]
        public string Visibilidade { get; set; } = null!;
    }
}

