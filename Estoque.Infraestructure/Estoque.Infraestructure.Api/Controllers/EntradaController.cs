using Estoque.Application.Comand.Modelos;
using Estoque.Application.Repository.RepositoryCategoria;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IService<Entrada> serviceAPI;
        private readonly IServiceDTO<EntradaDTO> serviceAPIDto;
        public EntradaController(IService<Entrada> serviceAPI, IServiceDTO<EntradaDTO> serviceAPIDto)
        {
            this.serviceAPI = serviceAPI;
            this.serviceAPIDto = serviceAPIDto;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetEntradas()
        {
            try
            {
                var Entradas = await serviceAPIDto.Listar();

                if (Entradas == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Entradas);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> BuscarEntradas(string id)
        {
            try
            {
                var Entrada = await serviceAPIDto.Buscar(id);

                if (Entrada == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Entrada);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar/{idProduto}")]
        public async Task<IActionResult> CadastrarEntrada(string idProduto, [FromBody] Entrada Entrada)
        {
            try
            {
                await serviceAPI.Cadastrar(idProduto, Entrada);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar/{idProduto}")]
        public async Task<IActionResult> AtualizarEntrada(string idProduto, [FromBody] Entrada Entrada)
        {
            try
            {
                await serviceAPI.Atualizar(idProduto, Entrada);

                return CreatedAtAction(nameof(BuscarEntradas), new { id = Entrada.id }, Entrada);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarEntrada(string id)
        {
            try
            {
                await serviceAPI.Deletar(id);

                return Ok("Entrada deletado");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
