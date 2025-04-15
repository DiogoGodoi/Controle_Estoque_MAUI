using Estoque.Application.Repository.RepositoryCategoria;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;
using Estoque.Application.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalEstoqueController : ControllerBase
    {
        private readonly IService<LocalEstoque> _serviceLocalEstoque;
        public LocalEstoqueController(IService<LocalEstoque> serviceLocalEstoque)
        {
            _serviceLocalEstoque = serviceLocalEstoque;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetLocalEstoques()
        {
            try
            {
                var LocalEstoques = await _serviceLocalEstoque.Listar();

                if (LocalEstoques == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(LocalEstoques.toLocaisEstoqueDTO());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> BuscarLocalEstoques(string id)
        {
            try
            {
                var LocalEstoque = await _serviceLocalEstoque.Buscar(id);

                if (LocalEstoque == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(LocalEstoque.toLocalEstoqueDTO());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> CadastrarLocalEstoque([FromBody] LocalEstoque LocalEstoque)
        {
            try
            {
                await _serviceLocalEstoque.Cadastrar(string.Empty, LocalEstoque);

                return CreatedAtAction(nameof(BuscarLocalEstoques), new { id = LocalEstoque.id }, LocalEstoque);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar/{idLocalEstoque}")]
        public async Task<IActionResult> AtualizarLocalEstoque(string idLocalEstoque, [FromBody] LocalEstoque LocalEstoque)
        {
            try
            {
                await _serviceLocalEstoque.Atualizar(idLocalEstoque, LocalEstoque);

                return CreatedAtAction(nameof(BuscarLocalEstoques), new { id = LocalEstoque.id }, LocalEstoque);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarLocalEstoque(string id)
        {
            try
            {
                await _serviceLocalEstoque.Deletar(id);

                return Ok("Local de estoque deletado");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
