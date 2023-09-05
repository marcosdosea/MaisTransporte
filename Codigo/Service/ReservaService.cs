using Core;
using Core.Service;

namespace Service
{
    public class ReservaService : IReservaService
    {
        private readonly MaisTransporteContext _context;

        public ReservaService(MaisTransporteContext context)
        {
            _context = context;
        }

        public int Create(Reserva reserva)
        {
            _context.Add(reserva);
            _context.SaveChanges();
            return reserva.Id;
        }

        public Reserva Get(int id)
        {
            return _context.Reservas.Find(id);
        }

        public void Delete(int id)
        {
            var reserva = _context.Reservas.Find(id);
            _context.Remove(reserva);
            _context.SaveChanges();
        }

        public IEnumerable<Reserva> GetAll()
        {
            return _context.Reservas;
        }
    }
}
