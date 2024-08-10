using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;

public interface IAvaliacaoViagemService
{
    uint Create(Avaliacao avaliacao);

    Avaliacao Get(uint id);

    IEnumerable<Avaliacao> GetAll();

}
