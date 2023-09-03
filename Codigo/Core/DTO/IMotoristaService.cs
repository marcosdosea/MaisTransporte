namespace Core.Service
{
    public interface IMotoristaService
    {
        int Create(Passageiro motorista);
        Passageiro Get(int id);
        void Edit(Passageiro motorista);
        void Delete(int id);
        IEnumerable<Passageiro> GetAll();
    }
}
