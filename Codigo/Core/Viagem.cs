using System;
using System.Collections.Generic;

namespace Core;

public partial class Viagem
{
    public int Id { get; set; }

    public TimeSpan DataIda { get; set; }

    public TimeSpan DataVolta { get; set; }

    public string LocalOrigem { get; set; } = null!;

    public string LocalDestino { get; set; } = null!;

    public TimeSpan HorarioIda { get; set; }

    public TimeSpan HorarioVolta { get; set; }

    public string Descricao { get; set; } = null!;

    public int IdMotorista { get; set; }

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual ICollection<Reembolso> Reembolsos { get; set; } = new List<Reembolso>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Passageiro> IdPassageiros { get; set; } = new List<Passageiro>();
}
