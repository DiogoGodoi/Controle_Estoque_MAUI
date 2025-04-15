using Estoque.Application.DTO;
using Estoque.Infraestructure.Http.Interface;
using System.Net.Http.Json;

namespace Estoque.Infraestructure.Http.Request.HttpProdutoSaida
{
    public class HttpProdutoSaidaRepository:IHttpRepositoryDTO<ProdutoSaidaDTO>
    {
        private readonly HttpClient _httpClient;
        public HttpProdutoSaidaRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ProdutoSaidaDTO> Buscar(string id)
        {
            try
            {
                var url = $"https://localhost:7170/api/ProdutoSaida/Buscar/{id}";

                var produtoSaida = await _httpClient.GetFromJsonAsync<ProdutoSaidaDTO>(url);

                return produtoSaida;

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
        public async Task<IEnumerable<ProdutoSaidaDTO>> Listar()
        {
            try
            {
                var url = $"https://localhost:7170/api/ProdutoSaida/Listar";

                var produtoSaidas = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoSaidaDTO>>(url);

                return produtoSaidas;

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
