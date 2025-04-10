using Estoque.Application.Comand.Modelos;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IService<Perfil> _servicePerfil;
        private readonly IServiceDTO<PerfilDTO> _servicePerfilDTO;
        public PerfilController(IService<Perfil> servicePerfil, IServiceDTO<PerfilDTO> servicePerfilDTO)
        {
            _servicePerfil = servicePerfil;
            _servicePerfilDTO = servicePerfilDTO;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetPerfils()
        {
            try
            {
                var Perfils = await _servicePerfilDTO.Listar();

                if (Perfils == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Perfils);
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
                var Perfil = await _servicePerfilDTO.Buscar(id);

                if (Perfil == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Perfil);
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
