using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Interfaces;
using System.Net.Http.Json;

namespace Estoque.Infraestructure.Http.Request.HttpLocalEstoque
{
    public class HttpLocalEstoqueRequest : IHttpRepository<LocalEstoque, LocalEstoqueDTO>
    {
        private readonly HttpClient _httpClient;
        public HttpLocalEstoqueRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LocalEstoque> Atualizar(string id, LocalEstoque objeto)
        {
            try
            {
                var url = $"{id}";

                HttpResponseMessage response = await _httpClient.PutAsJsonAsync(url, objeto);

                var LocalEstoque = await response.Content.ReadFromJsonAsync<LocalEstoque>();

                return LocalEstoque;

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
        public async Task<LocalEstoque> Cadastrar(LocalEstoque objeto)
        {
            try
            {
                var url = $"";

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, objeto);

                var LocalEstoque = await response.Content.ReadFromJsonAsync<LocalEstoque>();

                return LocalEstoque;
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
        public async Task<LocalEstoqueDTO> Buscar(string id)
        {
            try
            {
                var url = $"";

                var LocalEstoque = await _httpClient.GetFromJsonAsync<LocalEstoqueDTO>(url);

                return LocalEstoque;

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
        public async Task<IEnumerable<LocalEstoqueDTO>> Listar()
        {
            try
            {
                var url = $"https://localhost:7170/api/LocalEstoque/Listar";

                var LocalEstoques = await _httpClient.GetFromJsonAsync<IEnumerable<LocalEstoqueDTO>>(url);

                return LocalEstoques;

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
