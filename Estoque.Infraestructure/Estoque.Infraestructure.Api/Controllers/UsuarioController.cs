using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IService<Usuario> serviceUsuario;
        public UsuarioController(IService<Usuario> serviceUsuario)
        {
            this.serviceUsuario = serviceUsuario;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                var Usuarios = await serviceUsuario.Listar();

                if (Usuarios == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Usuarios);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> BuscarUsuarios(string id)
        {
            try
            {
                var Usuario = await serviceUsuario.Buscar(id);

                if (Usuario == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Usuario);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario Usuario)
        {
            try
            {
                await serviceUsuario.Cadastrar(string.Empty, Usuario);

                return CreatedAtAction(nameof(BuscarUsuarios), new { id = Usuario.id }, Usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] Usuario Usuario)
        {
            try
            {
                await serviceUsuario.Atualizar(Usuario.id.ToString(), Usuario);

                return Ok("Usuario atualizado");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarUsuario(string id)
        {
            try
            {
                await serviceUsuario.Deletar(id);

                return Ok("Usuario deletado");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
