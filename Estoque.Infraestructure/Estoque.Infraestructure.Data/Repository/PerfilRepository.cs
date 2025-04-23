using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Extend;
using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class PerfilRepository : IRepository<Perfil>
    {
        private readonly ContextSqlServer ContextSqlServer;
        public PerfilRepository(ContextSqlServer ContextSqlServer)
        {
            this.ContextSqlServer = ContextSqlServer;
        }
        public async Task Atualizar(string id, Perfil objeto)
        {
            try
            {
                var PerfilMapping = objeto.toPerfilEF();

                var PerfilEF = await ContextSqlServer.perfis.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (PerfilEF == null)
                    throw new Exception("Perfil não encontrado");

                if (PerfilEF.nome == objeto.nome)
                    throw new Exception("Já existe uma Perfil com esse nome");

                PerfilEF.nome = PerfilMapping.nome;

                ContextSqlServer.perfis.Update(PerfilEF);

                await ContextSqlServer.SaveChangesAsync();
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
                var Perfil = await ContextSqlServer.perfis
                                                  .Include(x => x.usuario)
                                                  .FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (Perfil == null)
                    throw new Exception("Perfil não localizado");

                var usuarioMappingDomain = Perfil.toPerfil();

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
                var PerfilEf = await ContextSqlServer.perfis.FirstOrDefaultAsync(x => x.nome == objeto.nome);
                if (PerfilEf != null) throw new Exception("Perfil já cadastrado");

                var Perfil = objeto.toPerfilEF();

                ContextSqlServer.perfis.Add(Perfil);

                await ContextSqlServer.SaveChangesAsync();

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
                var PerfilEF = await ContextSqlServer.perfis.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (PerfilEF == null)
                    throw new Exception("Perfil não encontrado");

                ContextSqlServer.perfis.Remove(PerfilEF);

                await ContextSqlServer.SaveChangesAsync();
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
                var usuarios = await ContextSqlServer.perfis
                                     .Include(x => x.usuario)
                                     .ToListAsync();

                var usuarioMappingDomain = usuarios.toPerfis();

                return usuarioMappingDomain.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
