using Core.DTO;

namespace Core.Service
{
    public interface IViagemService
    {
        int Create(Viagem viagem);
        Viagem Get(int id);

        IEnumerable<Viagem> GetAll();
        IEnumerable<ViagemDto> GetByLocalDestino(string localdestino);
    }
}
