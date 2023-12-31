﻿using Core;
using Core.DTO;
using Core.Service;

namespace Service
{
    /// <summary>
    /// Manter dados de sugestões de viagens no banco de dados
    /// </summary>
    public class SugerirViagemService : ISugerirViagemService
    {
        private readonly MaisTransporteContext _context;

        public SugerirViagemService(MaisTransporteContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere uma nova sugestão de viagem na base de dados
        /// </summary>
        /// <param name="sugestaoviagem">dados da sugestão de viagem</param>
        /// <returns></returns>
        public int Create(Sugestaoviagem sugestaoviagem)
        {
            _context.Add(sugestaoviagem);
            _context.SaveChanges();
            return sugestaoviagem.Id;
        }

        public Sugestaoviagem Get(int id)
        {
            return _context.Sugestaoviagems.Find(id);
        }

        /// <summary>
        /// Obtém todas as sugestões de viagens
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Sugestaoviagem> GetAll()
        {
            return _context.Sugestaoviagems;
        }

        /// <summary>
        /// Obtém as sugestões de viagens que possuem o localDestino
        /// </summary>
        /// <param name="localDestino">localDestino a ser buscado</param>
        /// <returns></returns>
        public IEnumerable<SugerirViagemDto> GetByLocalDestino(string localDestino)
        {
            IQueryable<Sugestaoviagem> tb_sugestaoViagem = _context.Sugestaoviagems;
            var query = from sugestaoviagem in tb_sugestaoViagem
                        where localDestino.StartsWith(localDestino)
                        orderby sugestaoviagem.LocalDestino descending
                        select new SugerirViagemDto
                        {
                            LocalDestino = sugestaoviagem.LocalDestino
                        };
            return query;
        }

    }
}
