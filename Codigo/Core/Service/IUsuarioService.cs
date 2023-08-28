using Core.DTO;

namespace Core.Service
{
    public interface IUsuarioService
    {
        int Create(Passageiro passageiro);
        Passageiro Get(int id);
        void Edit(Passageiro passageiro);
        void Delete(int id);
        IEnumerable<Passageiro> GetAll();
    }
}

