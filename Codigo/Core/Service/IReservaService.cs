namespace Core.Service
{
    public interface IReservaService
    {
        int Create(Reserva reserva);
        Reserva Get(int id);
        void Delete(int id);
        IEnumerable<Reserva> GetAll();
    }
}
