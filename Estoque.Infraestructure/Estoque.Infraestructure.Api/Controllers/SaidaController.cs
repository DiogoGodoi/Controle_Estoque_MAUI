using Estoque.Application.Comand.Modelos;
using Estoque.Application.Repository.RepositoryProduto;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Interface;

using Microsoft.AspNetCore.Mvc;

namespace Estoque.Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaidaController : ControllerBase
    {
        private readonly IService<Saida> _ServiceSaidas;
        private readonly IServiceDTO<SaidaDTO> _ServiceSaidasDTO;
        public SaidaController(IService<Saida> serviceSaidas, IServiceDTO<SaidaDTO> ServiceSaidasDTO)
        {
            _ServiceSaidas = serviceSaidas;
            _ServiceSaidasDTO = ServiceSaidasDTO;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetSaidas()
        {
            try
            {
                var Saidas = await _ServiceSaidasDTO.Listar();

                if (Saidas == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Saidas);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> BuscarSaidas(string id)
        {
            try
            {
                var Saida = await _ServiceSaidasDTO.Buscar(id);

                if (Saida == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Saida);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar/{idProduto}")]
        public async Task<IActionResult> CadastrarSaida(string idProduto, [FromBody] Saida Saida)
        {
            try
            {
                await _ServiceSaidas.Cadastrar(idProduto, Saida);

                return CreatedAtAction(nameof(BuscarSaidas), new { id = Saida.id }, Saida);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar/{idProduto}")]
        public async Task<IActionResult> AtualizarSaida(string idProduto, [FromBody] Saida Saida)
        {
            try
            {
                await _ServiceSaidas.Atualizar(idProduto, Saida);

                return CreatedAtAction(nameof(BuscarSaidas), new { id = Saida.id }, Saida);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarSaida(string id)
        {
            try
            {
                await _ServiceSaidas.Deletar(id);

                return Ok("Saida deletado");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
