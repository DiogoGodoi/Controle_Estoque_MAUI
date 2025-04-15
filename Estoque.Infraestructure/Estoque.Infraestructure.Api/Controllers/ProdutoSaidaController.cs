using Estoque.Application.Extensions;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoSaidaController : ControllerBase
    {
        private readonly IService<ProdutoSaida> service;
        public ProdutoSaidaController(IService<ProdutoSaida> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetProdutoSaida()
        {
            try
            {
                var ProdutoSaidas = await service.Listar();

                if (ProdutoSaidas == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(ProdutoSaidas.toProdutoSaidasDTO());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> BuscarProdutoSaidas(string id)
        {
            try
            {
                var ProdutoSaida = await service.Buscar(id);

                if (ProdutoSaida == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ProdutoSaida.toProdutoSaidaDTO());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> CadastrarProdutoSaida([FromBody] ProdutoSaida ProdutoSaida)
        {
            try
            {
                await service.Cadastrar(string.Empty, ProdutoSaida);

                return CreatedAtAction(nameof(BuscarProdutoSaidas), new { id = ProdutoSaida.saida.id }, ProdutoSaida);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar/{idProdutoSaida}")]
        public async Task<IActionResult> AtualizarProdutoSaida(string idProdutoSaida, [FromBody] ProdutoSaida ProdutoSaida)
        {
            try
            {
                await service.Atualizar(idProdutoSaida, ProdutoSaida);

                return CreatedAtAction(nameof(BuscarProdutoSaidas), new { id = ProdutoSaida.saida.id }, ProdutoSaida);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarProdutoSaida(string id)
        {
            try
            {
                await service.Deletar(id);

                return Ok("ProdutoSaida deletada");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
