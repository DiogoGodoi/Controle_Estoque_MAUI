using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Extend;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class UsuarioRepository : IRepository<Usuario>
    {

        private readonly EstoqueContext estoqueContext;
        public UsuarioRepository(EstoqueContext estoqueContext)
        {
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, Usuario objeto)
        {
            try
            {
                var usuariosMapping = objeto.toUsuarioEF();

                var usuarioEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (usuarioEf == null)
                    throw new Exception("Usuário não encontrado");

                if (usuarioEf.email == objeto.email)
                    throw new DbUpdateException("Já existe um usuário com esse e-mail");

                usuarioEf.email = usuariosMapping.email;
                usuarioEf.senha = usuariosMapping.senha;

                estoqueContext.usuarios.Update(usuarioEf);

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
        public async Task<Usuario> Buscar(string id)
        {

            try
            {
                var usuario = await estoqueContext.usuarios
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
                var usuariosEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.email == objeto.email);

                if (usuariosEf != null)
                    throw new Exception("Usuário já cadastrado");

                var perfilEf = await estoqueContext.perfis.FirstOrDefaultAsync(x => x.id == objeto.perfil.id);

                if (perfilEf == null)
                    throw new Exception("Perfil inexistente");

                var usuario = objeto.toUsuarioEF();

                usuario.perfil = perfilEf;

                estoqueContext.usuarios.Add(usuario);

                await estoqueContext.SaveChangesAsync();

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
                var usuarioEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (usuarioEf == null)
                    throw new Exception("Usuário não encontrado");

                estoqueContext.usuarios.Remove(usuarioEf);

                await estoqueContext.SaveChangesAsync();
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
                var usuarios = await estoqueContext.usuarios
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
