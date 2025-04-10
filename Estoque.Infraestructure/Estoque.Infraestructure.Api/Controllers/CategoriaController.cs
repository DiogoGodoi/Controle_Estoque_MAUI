using Estoque.Application.Comand.Modelos;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IService<Categoria> _serviceCategoria;
        private readonly IServiceDTO<CategoriaDTO> _serviceCategoriaDTO;
        public CategoriaController(IService<Categoria> serviceCategoria, IServiceDTO<CategoriaDTO> serviceCategoriaDTO)
        {
            _serviceCategoria = serviceCategoria;
            _serviceCategoriaDTO = serviceCategoriaDTO;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetCategorias()
        {
            try
            {
                var Categorias = await _serviceCategoriaDTO.Listar();

                if (Categorias == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Categorias);
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
                var Categoria = await _serviceCategoriaDTO.Buscar(id);

                if (Categoria == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Categoria);
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
