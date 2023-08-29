using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    internal interface IVeiculoService
    {
        int Create(Veiculo veiculo);
        Veiculo Get(int id);
        void Edit(Veiculo veiculo);
        void Delete(int id);
        IEnumerable<Veiculo> GetAll();
    }
}
