using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Manter dados de Passageiro no banco de dados
    /// </summary>
    public class UsuarioService : IUsuarioService
    {
        private readonly MaisTransporteContext _context;

        public UsuarioService(MaisTransporteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere um novo passageiro na base de dados
        /// </summary>
        /// <param name="passageiro">dados do usuario</param>
        /// <returns></returns>
        public int Create(Passageiro passageiro)
        {
            _context.Add(passageiro);
            _context.SaveChanges();
            return passageiro.Id;
        }

        public Passageiro Get(int id)
        {
            return _context.Passageiros.Find(id);
        }

        /// <summary>
        /// Obtém todos os passageiros
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Passageiro> GetAll()
        {
            return _context.Passageiros;
        }

        /// <summary>
        /// Remover o passageiro da base de dados
        /// </summary>
        /// <param name="id">id do passageiro</param>
        public void Delete(int id)
        {
            var _passageiro = _context.Passageiros.Find(id);
            _context.Remove(_passageiro);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar dados do passageiro na base de dados
        /// </summary>
        /// <param name="passageiro"></param>
        /// <exception cref="ServiceException"></exception>
        public void Edit(Passageiro passageiro)
        {
            _context.Update(passageiro);
            _context.SaveChanges();
        }
    }
}
