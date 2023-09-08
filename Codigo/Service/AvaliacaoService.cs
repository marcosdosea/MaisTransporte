using Core;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// Manter avaliação viagens no banco de dados
    /// </summary>
    
    public class AvaliarViagemService : IAvaliacaoViagemService
    {
        private readonly MaisTransporteContext _context;

        public AvaliarViagemService(MaisTransporteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere uma nova avaliação na base de dados
        /// </summary>
        /// <param name="avaliacao">dados da avaliação</param>
        /// <returns></returns>
        public int Create(Avaliacao avaliacao)
        {
            _context.Add(avaliacao);
            _context.SaveChanges();
            return avaliacao.Id;
        }

        public Avaliacao Get(int id)
        {
            return _context.Avaliacaos.Find(id);
        }
        
        /// /// <summary>
        /// Obtém todas avaliações das viagens
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Avaliacao> GetAll()
        {
            return _context.Avaliacaos;
        }
    }
}
