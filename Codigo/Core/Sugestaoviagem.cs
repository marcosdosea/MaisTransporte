using System;
using System.Collections.Generic;

namespace Core;

public partial class Sugestaoviagem
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string LocalOrigem { get; set; } = null!;

    public string LocalDestino { get; set; } = null!;

    public float ValorPassagem { get; set; }

    public int TotalVagas { get; set; }

    public DateTime DataPartida { get; set; }

    public DateTime DataChegada { get; set; }

    public string Descricao { get; set; } = null!;

    /// <summary>
    /// P- PÚBLICA
    /// R- RESTRITA/PRIVADA
    /// </summary>
    public string Visibilidade { get; set; } = null!;

    public int IdPassageiro { get; set; }

    public virtual Passageiro IdPassageiroNavigation { get; set; } = null!;

    public virtual ICollection<Passageiro> IdPassageiros { get; set; } = new List<Passageiro>();
}
