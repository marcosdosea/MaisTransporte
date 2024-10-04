using Core;
using Core.DTO;
using Core.Service;

namespace Service
{
    /// <summary>
    /// Manter dados de sugestões de viagens no banco de dados
    /// </summary>
    public class SugestaoviagemService : ISugestaoviagemService
    {
        private readonly MaisTransporteContext _context;

        public SugestaoviagemService(MaisTransporteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere uma nova sugestão de viagem na base de dados
        /// </summary>
        /// <param name="sugestaoviagem">dados da sugestão de viagem</param>
        /// <returns></returns>
        public int Create(Sugestaoviagem sugestaoviagem)
        {
            _context.Add(sugestaoviagem);
            _context.SaveChanges();
            return sugestaoviagem.Id;
        }

        public void Delete(int id)
        {
            var sugestaoViagem = _context.Sugestaoviagems.Find(id);
            if (sugestaoViagem != null)
            {
                _context.Sugestaoviagems.Remove(sugestaoViagem);
                _context.SaveChanges();
            }
        }


        public Sugestaoviagem Get(int id)
        {
            return _context.Sugestaoviagems.Find(id);
        }

        /// <summary>
        /// Obtém todas as sugestões de viagens
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Sugestaoviagem> GetAll()
        {
            return _context.Sugestaoviagems;
        }

        /// <summary>
        /// Obtém as sugestões de viagens que possuem o localDestino
        /// </summary>
        /// <param name="localDestino">localDestino a ser buscado</param>
        /// <returns></returns>
        public IEnumerable<SugestaoviagemDto> GetByLocalDestino(string localDestino)
        {
            IQueryable<Sugestaoviagem> tb_sugestaoViagem = _context.Sugestaoviagems;
            var query = from sugestaoviagem in tb_sugestaoViagem
                        where localDestino.StartsWith(localDestino)
                        orderby sugestaoviagem.LocalDestino descending
                        select new SugestaoviagemDto
                        {
                            LocalDestino = sugestaoviagem.LocalDestino
                        };
            return query;
        }

    }
}
