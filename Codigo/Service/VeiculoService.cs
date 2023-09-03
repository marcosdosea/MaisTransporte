using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// Manter dados de veículos no banco de dados
    /// </summary>
    public class VeiculoService : IVeiculoService
    {
        private readonly MaisTransporteContext _context;

        public VeiculoService(MaisTransporteContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Insere um novo veículo na base de dados
        /// </summary>
        /// <param name="veiculo">dados do veículo</param>
        /// <returns></returns>
        public int Create(Veiculo veiculo)
        {
            _context.Add(veiculo);
            _context.SaveChanges();
            return veiculo.Id;
        }

        /// <summary>
        /// Atualizar dados de um veículo da base de dados
        /// </summary>
        /// <param name="veiculo">novos dados do veículo</param>
        public void Edit(Veiculo veiculo)
        {
            _context.Update(veiculo);
            _context.SaveChanges();
        }

        public Veiculo Get(int id)
        {
            return _context.Veiculos.Find(id);
        }
        /// <summary>
        /// Obtém todos os veículos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Veiculo> GetAll()
        {
            return _context.Veiculos;
        }
    }
}
