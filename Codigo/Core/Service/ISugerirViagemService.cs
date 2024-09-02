using Core.DTO;

namespace Core.Service
{
    public interface ISugerirViagemService
    {
        int Create(Sugestaoviagem sugestaoViagem);
        void Delete(int id);
        Sugestaoviagem Get(int id);
        IEnumerable<Sugestaoviagem> GetAll();
        IEnumerable<SugerirViagemDto> GetByLocalDestino(string localDestino);
    }
}
