using Estoque.Application.DTO;
using Estoque.Infraestructure.Http.Interface;
using System.Net.Http.Json;

namespace Estoque.Infraestructure.Http.Request.HttpProdutoEntrada
{
    public class HttpProdutoEntradaRepository : IHttpRepositoryDTO<ProdutoEntradaDTO>
    {
        private readonly HttpClient _httpClient;
        public HttpProdutoEntradaRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ProdutoEntradaDTO> Buscar(string id)
        {
            try
            {
                var url = $"https://localhost:7170/api/ProdutoEntrada/Buscar/{id}";

                var produtoEntrada = await _httpClient.GetFromJsonAsync<ProdutoEntradaDTO>(url);

                return produtoEntrada;

            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Erro de servidor: {ex.Message}");
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<ProdutoEntradaDTO>> Listar()
        {
            try
            {
                var url = $"https://localhost:7170/api/ProdutoEntrada/Listar";

                var produtoEntradas = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoEntradaDTO>>(url);

                return produtoEntradas;

            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Erro de servidor: {ex.Message}");
            }
            catch
            {
                throw;
            }
        }
    }
}
