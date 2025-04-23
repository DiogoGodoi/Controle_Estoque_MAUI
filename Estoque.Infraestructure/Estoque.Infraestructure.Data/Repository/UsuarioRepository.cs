using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Extend;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class UsuarioRepository : IRepository<Usuario>
    {

        private readonly ContextSqlServer ContextSqlServer;
        public UsuarioRepository(ContextSqlServer ContextSqlServer)
        {
            this.ContextSqlServer = ContextSqlServer;
        }
        public async Task Atualizar(string id, Usuario objeto)
        {
            try
            {
                var usuariosMapping = objeto.toUsuarioEF();

                var usuarioEf = await ContextSqlServer.usuarios.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (usuarioEf == null)
                    throw new Exception("Usuário não encontrado");

                if (usuarioEf.email == objeto.email)
                    throw new DbUpdateException("Já existe um usuário com esse e-mail");

                usuarioEf.email = usuariosMapping.email;
                usuarioEf.senha = usuariosMapping.senha;

                ContextSqlServer.usuarios.Update(usuarioEf);

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
        public async Task<Usuario> Buscar(string id)
        {

            try
            {
                var usuario = await ContextSqlServer.usuarios
                    .Include(x => x.perfil)
                    .FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (usuario == null)
                    throw new Exception("Usuário não localizado");

                var usuarioMappingDomain = usuario.toUsuario();

                return usuarioMappingDomain;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Cadastrar(Usuario objeto)
        {
            try
            {
                var usuariosEf = await ContextSqlServer.usuarios.FirstOrDefaultAsync(x => x.email == objeto.email);

                if (usuariosEf != null)
                    throw new Exception("Usuário já cadastrado");

                var perfilEf = await ContextSqlServer.perfis.FirstOrDefaultAsync(x => x.id == objeto.perfil.id);

                if (perfilEf == null)
                    throw new Exception("Perfil inexistente");

                var usuario = objeto.toUsuarioEF();

                usuario.perfil = perfilEf;

                ContextSqlServer.usuarios.Add(usuario);

                await ContextSqlServer.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"{ex.Message}");
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
                var usuarioEf = await ContextSqlServer.usuarios.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (usuarioEf == null)
                    throw new Exception("Usuário não encontrado");

                ContextSqlServer.usuarios.Remove(usuarioEf);

                await ContextSqlServer.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("O registro possuí referências");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Usuario>> Listar()
        {
            try
            {
                var usuarios = await ContextSqlServer.usuarios
                                    .Include(x => x.perfil)
                                    .ToListAsync();

                var usuarioMappingDomain = usuarios.toUsuarios();

                return usuarioMappingDomain;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
