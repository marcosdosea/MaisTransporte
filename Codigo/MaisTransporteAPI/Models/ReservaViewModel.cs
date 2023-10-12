using System.ComponentModel.DataAnnotations;

namespace MaisTransporteWeb.Models
{
    public class ReservaViewModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataCompra { get; set; }

        public string StausPagamento { get; set; } = null!;

        public float ValorPagamento { get; set; }

        public int IdViagem { get; set; }

        public int IdPassageiro { get; set; }
    }
}
