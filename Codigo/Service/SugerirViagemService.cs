using Core;
using Core.DTO;
using Core.Service;

namespace Service
{
    public class SugerirViagemService : ISugerirViagemService
    {
        private readonly MaisTransporteContext _context;

        public SugerirViagemService(MaisTransporteContext context)
        {
            _context = context;
        }

        public int Create(Sugestaoviagem sugestaoviagem)
        {
            _context.Add(sugestaoviagem);
            _context.SaveChanges();
            return sugestaoviagem.Id;
        }

        public Sugestaoviagem Get(int id)
        {
            return _context.Sugestaoviagems.Find(id);
        }

        public IEnumerable<Sugestaoviagem> GetAll()
        {
            return _context.Sugestaoviagems;
        }

        public IEnumerable<SugestaoViagemDto> GetByLocalDestino(string localDestino)
        {
            throw new NotImplementedException();
        }

    }
}
