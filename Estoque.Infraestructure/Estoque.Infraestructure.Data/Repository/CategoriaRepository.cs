using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Infraestructure.Data.Context;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Infraestructure.Data.Repository
{
    public class CategoriaRepository : IRepository<Categoria>
    {
        private readonly IMapper mapper;

        private readonly EstoqueContext estoqueContext;
        public CategoriaRepository(IMapper mapper, EstoqueContext estoqueContext)
        {
            this.mapper = mapper;
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, Categoria objeto)
        {
            try
            {
                var CategoriaMapping = mapper.Map<CategoriaDTO>(objeto);

                var CategoriaEF = await estoqueContext.categorias.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (CategoriaEF == null)
                    throw new Exception("Categoria não encontrada");

                if (CategoriaEF.nome == objeto.nome)
                    throw new Exception("Já existe uma categoria com esse nome");

                CategoriaEF.fk_Usuario_id = CategoriaMapping.fk_Usuario_id;
                CategoriaEF.nome = CategoriaMapping.nome;

                estoqueContext.categorias.Update(CategoriaEF);

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
        public async Task<Categoria> Buscar(string id)
        {

            try
            {
                var categoria = await estoqueContext.categorias
                                     .Include(x => x.produto)
                                     .Include(x => x.usuario)
                                     .FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (categoria == null)
                    throw new Exception("Categoria não localizada");

                var usuarioMappingDomain = mapper.Map<Categoria>(categoria);

                return usuarioMappingDomain;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(Categoria objeto)
        {
            try
            {
                var categoriaEf = await estoqueContext.categorias.FirstOrDefaultAsync(x => x.nome == objeto.nome);
                if (categoriaEf != null) throw new Exception("Categoria já cadastrada");

                var usuarioEF = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.id == objeto.usuario.id);
                if (usuarioEF == null) throw new Exception("Usuário não encontrado");

                var categoria = mapper.Map<CategoriaDTO>(objeto);
                categoria.usuario = usuarioEF;

                estoqueContext.categorias.Add(categoria);

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
                var CategoriaEF = await estoqueContext.categorias.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (CategoriaEF == null)
                    throw new Exception("Categoria não encontrada");

                estoqueContext.categorias.Remove(CategoriaEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Existem produtos referenciados com esta categoria");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Categoria>> Listar()
        {
            try
            {
                var usuarios = await estoqueContext.categorias
                                     .Include(x => x.produto)
                                     .Include(x => x.usuario).ToListAsync();

                var usuarioMappingDomain = mapper.Map<IEnumerable<Categoria>>(usuarios);

                return usuarioMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
