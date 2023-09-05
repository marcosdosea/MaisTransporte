using Core;
using Core.Service;

namespace Service
{
    /// <summary>
    /// Manter dados de reservas no banco de dados
    /// </summary>
    public class ReservaService : IReservaService
    {
        private readonly MaisTransporteContext _context;

        public ReservaService(MaisTransporteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere uma reserva na base de dados
        /// </summary>
        /// <param name="reserva">dados da reserva</param>
        /// <returns></returns>
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

        /// <summary>
        /// Remove a reserva da base de dados
        /// </summary>
        /// <param name="id">id da reserva</param>
        public void Delete(int id)
        {
            var reserva = _context.Reservas.Find(id);
            _context.Remove(reserva);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtém todas as reservas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Reserva> GetAll()
        {
            return _context.Reservas;
        }
    }
}
