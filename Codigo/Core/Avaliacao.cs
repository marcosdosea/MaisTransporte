using System;
using System.Collections.Generic;

namespace Core;

public partial class Avaliacao
{
    public uint Id { get; set; }

    public int Nota { get; set; }

    public string? Comentario { get; set; }

    public int IdPassageiro { get; set; }

    public int IdViagem { get; set; }

    public virtual Passageiro IdPassageiroNavigation { get; set; } = null!;

    public virtual Viagem IdViagemNavigation { get; set; } = null!;
}
