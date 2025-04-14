using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;
using Estoque.Infraestructure.Data.AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IService<Categoria> _serviceCategoria;
        public CategoriaController(IService<Categoria> serviceCategoria)
        {
            _serviceCategoria = serviceCategoria;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetCategorias()
        {
            try
            {
                var Categorias = await _serviceCategoria.Listar();

                if (Categorias == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(Categorias.ToCategoriasDTO());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> BuscarCategorias(string id)
        {
            try
            {
                var Categoria = await _serviceCategoria.Buscar(id);

                if (Categoria == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Categoria.toCategoriaDTO());
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> CadastrarCategoria([FromBody] Categoria Categoria)
        {
            try
            {
                await _serviceCategoria.Cadastrar(string.Empty, Categoria);

                return CreatedAtAction(nameof(BuscarCategorias), new { id = Categoria.id }, Categoria);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar/{idCategoria}")]
        public async Task<IActionResult> AtualizarCategoria(string idCategoria, [FromBody] Categoria Categoria)
        {
            try
            {
                await _serviceCategoria.Atualizar(idCategoria, Categoria);

                return CreatedAtAction(nameof(BuscarCategorias), new { id = Categoria.id}, Categoria);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarCategoria(string id)
        {
            try
            {
                await _serviceCategoria.Deletar(id);

                return Ok("Categoria deletada");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
