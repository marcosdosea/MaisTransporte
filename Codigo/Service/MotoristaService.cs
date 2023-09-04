using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Manter dados de Passageiro no banco de dados
    /// </summary>
    public class MotoristaService : IMotoristaService
    {
        private readonly MaisTransporteContext _context;

        public MotoristaService(MaisTransporteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere um novo motorista na base de dados
        /// </summary>
        /// <param name="motorista">dados do usuario</param>
        /// <returns></returns>
        public int Create(Motoristum motorista)
        {
            _context.Add(motorista);
            _context.SaveChanges();
            return motorista.IdPassageiro;
        }

        public Motoristum Get(int idpassageiro)
        {
            return _context.Motorista.Find(idpassageiro);
        }

        /// <summary>
        /// Obtém todos os motoristas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Motoristum> GetAll()
        {
            return _context.Motorista; 
        }

        /// <summary>
        /// Remover o motorista da base de dados
        /// </summary>
        /// <param name="idpassageiro">id do motorista</param>
        public void Delete(int idpassageiro)
        {
            var _motorista = _context.Motorista.Find(idpassageiro);
            _context.Remove(_motorista);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar dados do motorista na base de dados
        /// </summary>
        /// <param name="motorista"></param>
        /// <exception cref="ServiceException"></exception>
        public void Edit(Motoristum motorista)
        {
            _context.Update(motorista);
            _context.SaveChanges();
        }
    }
}
