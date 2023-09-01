using System;
using System.Collections.Generic;

namespace Core;

public partial class Veiculo
{
    public int Id { get; set; }

    public string Renavam { get; set; } = null!;

    public string Placa { get; set; } = null!;

    public DateTime DataEmissao { get; set; }

    public string Expeditor { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public int IdMotoristaPassageiro { get; set; }

    public virtual Motoristum IdMotoristaPassageiroNavigation { get; set; } = null!;
}
