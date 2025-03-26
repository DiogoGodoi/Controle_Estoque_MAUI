using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infraestructure.Data.Repository
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly IMapper mapper;

        private readonly EstoqueContext estoqueContext;
        public UsuarioRepository(IMapper mapper, EstoqueContext estoqueContext)
        {
            this.mapper = mapper;
            this.estoqueContext = estoqueContext;
        }
        public async Task Atualizar(string id, Usuario objeto)
        {
            try
            {
                var usuariosMapping = mapper.Map<UsuarioEF>(objeto);

                var usuarioEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (usuarioEf == null)
                    throw new Exception("Usuário não encontrado");

                if(usuarioEf.email == objeto.email)
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
                var usuario = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.id == Guid.Parse(id));

                if (usuario == null)
                    throw new Exception("Usuário não localizado");

                var usuarioMappingDomain = mapper.Map<Usuario>(usuario);

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

                var perfilEf = await estoqueContext.perfis.FirstOrDefaultAsync(x => x.id == objeto.fk_Perfil_id);

                if (perfilEf == null)
                    throw new Exception("Perfil inexistente");

                var usuario = mapper.Map<UsuarioEF>(objeto);

                usuario.perfil = perfilEf;

                estoqueContext.usuarios.Add(usuario);

                await estoqueContext.SaveChangesAsync();

            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"{ex.Message}");
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
                var usuarios = await estoqueContext.usuarios.ToListAsync();

                var usuarioMappingDomain = mapper.Map<IEnumerable<Usuario>>(usuarios);

                return usuarioMappingDomain;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
