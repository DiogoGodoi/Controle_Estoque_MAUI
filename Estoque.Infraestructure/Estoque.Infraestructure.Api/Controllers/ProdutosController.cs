using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IService<Produto> _produtoService;
        public ProdutosController(IService<Produto> produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetProdutos()
        {
            try
            {
                var produtos = await _produtoService.Listar();

                if (produtos == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(produtos);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> BuscarProdutos(string id)
        {
            try
            {
                var produto = await _produtoService.Buscar(id);

                if (produto == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(produto);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> CadastrarProduto([FromBody] Produto produto)
        {
            try
            {
                await _produtoService.Cadastrar(string.Empty, produto);

                return CreatedAtAction(nameof(BuscarProdutos), new { descricao = produto.descricao }, produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> AtualizarProduto([FromBody] Produto produto)
        {
            try
            {
                await _produtoService.Atualizar(produto.id.ToString(), produto);

                return Ok("Produto atualizado");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarProduto(string id)
        {
            try
            {
                await _produtoService.Deletar(id);

                return Ok("produto deletado");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
