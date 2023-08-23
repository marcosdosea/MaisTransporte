using System;
using System.Collections.Generic;

namespace Core;

public partial class Reembolso
{
    public uint Id { get; set; }

    public DateTime Data { get; set; }

    public float Valor { get; set; }

    public int IdPassageiro { get; set; }

    public int IdViagem { get; set; }

    public virtual Passageiro IdPassageiroNavigation { get; set; } = null!;

    public virtual Viagem IdViagemNavigation { get; set; } = null!;
}
