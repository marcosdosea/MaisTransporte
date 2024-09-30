using Core.DTO;

namespace Core.Service
{
    public interface ISugestaoviagemService
    {
        int Create(Sugestaoviagem sugestaoViagem);
        void Delete(int id);
        Sugestaoviagem Get(int id);
        IEnumerable<Sugestaoviagem> GetAll();
        IEnumerable<SugestaoviagemDto> GetByLocalDestino(string localDestino);
    }
}
