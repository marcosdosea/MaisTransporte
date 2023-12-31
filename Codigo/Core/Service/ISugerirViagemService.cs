﻿using Core.DTO;

namespace Core.Service
{
    public interface ISugerirViagemService
    {
        int Create(Sugestaoviagem sugestaoViagem);
        Sugestaoviagem Get(int id);

        IEnumerable<Sugestaoviagem> GetAll();
        IEnumerable<SugerirViagemDto> GetByLocalDestino(string localDestino);
    }
}
