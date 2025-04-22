using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Interfaces;
using System.Net.Http.Json;

namespace Estoque.Infraestructure.Http.Request.HttpProdutoSaida
{
    public class HttpProdutoSaidaRequest: IHttpRepository<ProdutoSaida, ProdutoSaidaDTO>
    {
        private readonly HttpClient _httpClient;
        public HttpProdutoSaidaRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
        public Task<ProdutoSaida> Cadastrar(ProdutoSaida objeto)
        {
            throw new NotImplementedException();
        }
        public Task<ProdutoSaida> Atualizar(string id, ProdutoSaida objeto)
        {
            throw new NotImplementedException();
        }
        public Task<string> Deletar(string id)
        {
            throw new NotImplementedException();
        }
    }
}
