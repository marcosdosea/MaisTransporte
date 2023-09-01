using System;
using System.Collections.Generic;

namespace Core;

public partial class Motoristum
{
    public int IdPassageiro { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public DateTime DataEmissao { get; set; }

    public string Expeditor { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime DataValidacao { get; set; }

    public string Status { get; set; } = null!;

    public virtual Passageiro IdPassageiroNavigation { get; set; } = null!;

    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
