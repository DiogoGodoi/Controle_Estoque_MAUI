using Estoque.Domain.Modelos;
using Estoque.Application.DTO;
using Estoque.Infraestructure.Http.Interface;
using System.Net.Http.Json;

namespace Estoque.Infraestructure.Http.Request.HttpProduto
{
    public class HttpProdutoRepository : IHttpRepository<Produto>, IHttpRepositoryDTO<ProdutoDTO>
    {
        private readonly HttpClient _httpClient;
        public HttpProdutoRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Produto> Atualizar(string id, Produto objeto)
        {
            try
            {
                var url = $"{id}";

                HttpResponseMessage response = await _httpClient.PutAsJsonAsync(url, objeto);

                var Produto = await response.Content.ReadFromJsonAsync<Produto>();

                return Produto;

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
        public async Task<Produto> Cadastrar(Produto objeto)
        {
            try
            {
                var url = $"";

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, objeto);

                var Produto = await response.Content.ReadFromJsonAsync<Produto>();

                return Produto;
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
        public async Task<string> Deletar(string id)
        {
            try
            {
                var url = $"";

                HttpResponseMessage response = await _httpClient.DeleteAsync(url);

                var content = await response.Content.ReadAsStringAsync();

                return content;

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
        public async Task<ProdutoDTO> Buscar(string id)
        {
            try
            {
                var url = $"";

                var Produto = await _httpClient.GetFromJsonAsync<ProdutoDTO>(url);

                return Produto;

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
        public async Task<IEnumerable<ProdutoDTO>> Listar()
        {
            try
            {
                var url = $"https://localhost:7170/api/Produtos/Listar";

                var Produtos = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDTO>>(url);

                return Produtos;

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
