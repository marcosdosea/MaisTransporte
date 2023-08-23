using System;
using System.Collections.Generic;

namespace Core;

public partial class Reserva
{
    public int Id { get; set; }

    public DateTime DataCompra { get; set; }

    public string StausPagamento { get; set; } = null!;

    public float ValorPagamento { get; set; }

    public int IdViagem { get; set; }

    public int IdPassageiro { get; set; }

    public virtual Passageiro IdPassageiroNavigation { get; set; } = null!;

    public virtual Viagem IdViagemNavigation { get; set; } = null!;
}
