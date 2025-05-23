﻿using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpSaida
{
    public class AtualizarSaidaHttp : IAtualizarHttp<Saida>
    {
        private readonly IHttpRepository<Saida, SaidaDTO> repository;
        public AtualizarSaidaHttp(IHttpRepository<Saida, SaidaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string id, Saida objeto)
        {
            return repository.Atualizar(id, objeto);
        }
    }
}
