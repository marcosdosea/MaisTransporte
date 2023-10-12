using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class AvaliarViagemViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Avaliar")]
        public int Nota { get; set; }

        [Display(Name = "Comentário")]
        [StringLength(200)]
        public string Comentario { get; set; } = null!;

        [Display(Name = "Código do Passageiro")]
        public int IdPassageiro { get; set; }

        [Display(Name = "Código da Viagem")]
        public int IdViagem { get; set; }
    }
}
