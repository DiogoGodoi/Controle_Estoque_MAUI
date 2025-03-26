using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class PerfilRepository : IRepository<Perfil>
    {
        private readonly IMapper mapper;

        private readonly EstoqueContext estoqueContext;
        public PerfilRepository(IMapper mapper, EstoqueContext estoqueContext)
        {
            this.mapper = mapper;
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, Perfil objeto)
        {
            try
            {
                var PerfilMapping = mapper.Map<PerfilEF>(objeto);

                var PerfilEF = await estoqueContext.perfis.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (PerfilEF == null)
                    throw new Exception("Perfil não encontrado");

                if(PerfilEF.nome == objeto.nome)
                    throw new Exception("Já existe uma Perfil com esse nome");

                PerfilEF.nome = PerfilMapping.nome;

                estoqueContext.perfis.Update(PerfilEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Perfil> Buscar(string id)
        {
            try
            {
                var Perfil = await estoqueContext.perfis.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (Perfil == null)
                    throw new Exception("Perfil não localizado");

                var usuarioMappingDomain = mapper.Map<Perfil>(Perfil);

                return usuarioMappingDomain;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(Perfil objeto)
        {
            try
            {
                var PerfilEf = await estoqueContext.perfis.FirstOrDefaultAsync(x => x.nome == objeto.nome);
                if (PerfilEf != null) throw new Exception("Perfil já cadastrado");

                var Perfil = mapper.Map<PerfilEF>(objeto);
                
                estoqueContext.perfis.Add(Perfil);

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
                var PerfilEF = await estoqueContext.perfis.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (PerfilEF == null)
                    throw new Exception("Perfil não encontrado");

                estoqueContext.perfis.Remove(PerfilEF);

                await estoqueContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Existem usuários referenciados com esse perfil");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Perfil>> Listar()
        {
            try
            {
                var usuarios = await estoqueContext.perfis.ToListAsync();

                var usuarioMappingDomain = mapper.Map<IEnumerable<Perfil>>(usuarios);

                return usuarioMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
