using Core.DTO;
using Core.Service;
using Core;

namespace Service
{
    public class ViagemService : IViagemService
    {
        private readonly MaisTransporteContext _context;

        public ViagemService(MaisTransporteContext context)
        {
            _context = context;
        }

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

        public IEnumerable<Viagem> GetAll()
        {
            return _context.Viagems;
        }

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
