﻿using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Infraestructure.Data.Context;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Infraestructure.Data.Repository
{
    public class LocalEstoqueRepository : IRepository<LocalEstoque>
    {
        private readonly IMapper mapper;

        private readonly EstoqueContext estoqueContext;
        public LocalEstoqueRepository(IMapper mapper, EstoqueContext estoqueContext)
        {
            this.mapper = mapper;
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, LocalEstoque objeto)
        {
            try
            {
                var LocalEstoqueMapping = mapper.Map<LocalEstoqueDTO>(objeto);

                var LocalEstoqueEF = await estoqueContext.locaisEstoque.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (LocalEstoqueEF == null)
                    throw new Exception("Local de estoque não encontrada");

                if (LocalEstoqueEF.nome == objeto.nome)
                    throw new Exception("Já existe um local de estoque com esse nome");

                LocalEstoqueEF.nome = LocalEstoqueMapping.nome;

                estoqueContext.locaisEstoque.Update(LocalEstoqueEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<LocalEstoque> Buscar(string id)
        {
            try
            {
                var LocalEstoque = await estoqueContext.locaisEstoque
                                         .Include(x => x.produtos)
                                         .FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (LocalEstoque == null)
                    throw new Exception("Local estoque não localizada");

                var localMappingDomain = mapper.Map<LocalEstoque>(LocalEstoque);

                return localMappingDomain;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(LocalEstoque objeto)
        {
            try
            {
                var LocalEstoqueEf = await estoqueContext.locaisEstoque.FirstOrDefaultAsync(x => x.nome == objeto.nome);
                if (LocalEstoqueEf != null) throw new Exception("LocalEstoque já cadastrada");

                var LocalEstoque = mapper.Map<LocalEstoqueDTO>(objeto);

                estoqueContext.locaisEstoque.Add(LocalEstoque);

                await estoqueContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Deletar(string id)
        {
            try
            {
                var LocalEstoqueEF = await estoqueContext.locaisEstoque.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));
                if (LocalEstoqueEF == null)
                    throw new Exception("Local de estoque não encontrado");

                estoqueContext.locaisEstoque.Remove(LocalEstoqueEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                throw new DbUpdateException($"Existem produtos nesse local de estoque");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<LocalEstoque>> Listar()
        {
            try
            {
                var locais = await estoqueContext.locaisEstoque
                                   .Include(x => x.produtos)
                                   .ToListAsync();

                var locaisMappingDomain = mapper.Map<IEnumerable<LocalEstoque>>(locais);

                return locaisMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
