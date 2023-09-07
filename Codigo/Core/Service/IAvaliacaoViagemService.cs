using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;

public interface IAvaliacaoViagemService
{
    int Create(Avaliacao avaliacao);

    Avaliacao Get(int id);

    IEnumerable<Avaliacao> GetAll();

}
