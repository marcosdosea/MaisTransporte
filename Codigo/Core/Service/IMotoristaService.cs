namespace Core.Service
{
    public interface IMotoristaService
    {
        int Create(Motoristum motorista);
        Motoristum Get(int id);
        void Edit(Motoristum motorista);
        void Delete(int id);
        IEnumerable<Motoristum> GetAll();
    }
}
