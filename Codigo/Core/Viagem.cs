using System;
using System.Collections.Generic;

namespace Core;

public partial class Viagem
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

    public int IdMotorista { get; set; }

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual ICollection<Reembolso> Reembolsos { get; set; } = new List<Reembolso>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Passageiro> IdPassageiros { get; set; } = new List<Passageiro>();
}
