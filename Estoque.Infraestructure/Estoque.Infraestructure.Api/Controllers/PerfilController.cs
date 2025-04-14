using Estoque.Application.Repository.RepositoryLocalEstoque;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;
using Estoque.Infraestructure.Data.AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IService<Perfil> _servicePerfil;
        public PerfilController(IService<Perfil> servicePerfil)
        {
            _servicePerfil = servicePerfil;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetPerfils()
        {
            try
            {
                var Perfils = await _servicePerfil.Listar();

                if (Perfils == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Perfils.toPerfisDTO());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> BuscarPerfils(string id)
        {
            try
            {
                var Perfil = await _servicePerfil.Buscar(id);

                if (Perfil == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Perfil.toPerfilDTO());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> CadastrarPerfil([FromBody] Perfil Perfil)
        {
            try
            {
                await _servicePerfil.Cadastrar(string.Empty, Perfil);

                return CreatedAtAction(nameof(BuscarPerfils), new { id = Perfil.id }, Perfil);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar/{idPerfil}")]
        public async Task<IActionResult> AtualizarPerfil(string idPerfil, [FromBody] Perfil Perfil)
        {
            try
            {
                await _servicePerfil.Atualizar(idPerfil, Perfil);

                return CreatedAtAction(nameof(BuscarPerfils), new { id = Perfil.id }, Perfil);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarPerfil(string id)
        {
            try
            {
                await _servicePerfil.Deletar(id);

                return Ok("Perfil deletado");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
