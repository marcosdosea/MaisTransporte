using System;
using System.Collections.Generic;

namespace Core;

public partial class Passageiro
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public string Telefone { get; set; } = null!;

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual Motorista? Motoristum { get; set; }

    public virtual ICollection<Reembolso> Reembolsos { get; set; } = new List<Reembolso>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Sugestaoviagem> Sugestaoviagems { get; set; } = new List<Sugestaoviagem>();

    public virtual ICollection<Sugestaoviagem> IdSugestaoViagems { get; set; } = new List<Sugestaoviagem>();

    public virtual ICollection<Viagem> IdViagems { get; set; } = new List<Viagem>();
}
