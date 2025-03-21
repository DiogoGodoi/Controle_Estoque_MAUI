using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Data.Context;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repository
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
        public async Task Atualizar(string email, Usuario objeto)
        {
            try
            {
                var usuariosMapping = mapper.Map<UsuarioEF>(objeto);

                var usuarioEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.email == email);

                if (usuarioEf == null)
                    throw new Exception("Usuário não encontrado");

                usuarioEf.email = usuariosMapping.email;
                usuarioEf.senha = usuariosMapping.senha;

                estoqueContext.usuarios.Update(usuarioEf);

                await estoqueContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Já existe um usuário com esse e-mail");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Usuario> Buscar(string email)
        {

            try
            {
                var usuario = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.email == email);

                if (usuario == null)
                    throw new Exception("Usuário não localizado");

                var usuarioMappingDomain = mapper.Map<Usuario>(usuario);

                return usuarioMappingDomain;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task Cadastrar(Usuario objeto)
        {
            try
            {
                var usuariosEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.email == objeto.email);

                if (usuariosEf != null)
                    throw new Exception("Usuário já cadastrado");

                var usuario = mapper.Map<UsuarioEF>(objeto);

                estoqueContext.usuarios.Add(usuario);

                await estoqueContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task Deletar(string email)
        {
            try
            {
                var usuarioEf = await estoqueContext.usuarios.FirstOrDefaultAsync(x => x.email == email);

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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
        }
    }
}
