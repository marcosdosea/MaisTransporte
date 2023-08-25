using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    internal interface IUsuarioService
    {
        int Inserir(Passageiro passageiro);

        int Inserir(Motorista motorista);

        void Alterar(Passageiro passageiro);

        void Alterar(Motorista motorista);

        Passageiro Buscar(int id);

        //Motorista Buscar(int idPassageiro);

        IEnumerable<Passageiro> ObterPorNome(string nome);

        //IEnumerable<Motorista> ObterPorNome(string nome);

        IEnumerable<Passageiro> ObterTodos();

        //IEnumerable<Motorista> ObterTodos();

        void Excluir(int idUsuario);

        IEnumerable<Passageiro> GetAll();

        //IEnumerable<Motorista> GetAll();

        IEnumerable<UsuarioDto> GetByNome(string nome);
    }
}
