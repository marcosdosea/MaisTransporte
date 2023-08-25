using Core.DTO;
using Core.Service;
using Core;

namespace Service
{
    /// <summary>
    /// Manter dados de viagens no banco de dados
    /// </summary>
    public class ViagemService : IViagemService
    {
        private readonly MaisTransporteContext _context;

        public ViagemService(MaisTransporteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere uma nova viagem na base de dados
        /// </summary>
        /// <param name="viagem">dados da viagem</param>
        /// <returns></returns>
        public int Create(Viagem viagem)
        {
            _context.Add(viagem);
            _context.SaveChanges();
            return viagem.Id;
        }

        public Viagem Get(int id)
        {
            return _context.Viagems.Find(id);
        }

        /// <summary>
        /// Obtém todas as viagens
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Viagem> GetAll()
        {
            return _context.Viagems;
        }

        /// <summary>
        /// Obtém viagens que possuem o localDestino
        /// </summary>
        /// <param name="localDestino">localDestino a ser buscado</param>
        /// <returns></returns>
        public IEnumerable<ViagemDto> GetByLocalDestino(string localDestino)
        {
            IQueryable<Viagem> tb_viagem = _context.Viagems;
            var query = from viagem in tb_viagem
                        where localDestino.StartsWith(localDestino)
                        orderby viagem.LocalDestino descending
                        select new ViagemDto
                        {
                            LocalDestino = viagem.LocalDestino
                        };
            return query;
        }

    }
}
