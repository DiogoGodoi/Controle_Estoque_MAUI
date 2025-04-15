using Estoque.Application.Extensions;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoEntradaController : ControllerBase
    {
        private readonly IService<ProdutoEntrada> service;
        public ProdutoEntradaController(IService<ProdutoEntrada> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetProdutoEntrada()
        {
            try
            {
                var ProdutoEntradas = await service.Listar();

                if (ProdutoEntradas == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(ProdutoEntradas.toProdutoEntradasDTO());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> BuscarProdutoEntradas(string id)
        {
            try
            {
                var ProdutoEntrada = await service.Buscar(id);

                if (ProdutoEntrada == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ProdutoEntrada.toProdutoEntradaDTO());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> CadastrarProdutoEntrada([FromBody] ProdutoEntrada ProdutoEntrada)
        {
            try
            {
                await service.Cadastrar(string.Empty, ProdutoEntrada);

                return CreatedAtAction(nameof(BuscarProdutoEntradas), new { id = ProdutoEntrada.entrada.id }, ProdutoEntrada);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar/{idProdutoEntrada}")]
        public async Task<IActionResult> AtualizarProdutoEntrada(string idProdutoEntrada, [FromBody] ProdutoEntrada ProdutoEntrada)
        {
            try
            {
                await service.Atualizar(idProdutoEntrada, ProdutoEntrada);

                return CreatedAtAction(nameof(BuscarProdutoEntradas), new { id = ProdutoEntrada.entrada.id }, ProdutoEntrada);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarProdutoEntrada(string id)
        {
            try
            {
                await service.Deletar(id);

                return Ok("ProdutoEntrada deletada");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
