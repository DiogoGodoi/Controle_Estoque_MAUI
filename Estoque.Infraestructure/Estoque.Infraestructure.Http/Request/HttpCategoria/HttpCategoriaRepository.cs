using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Interface;
using System.Net.Http.Json;

namespace Estoque.Infraestructure.Http.Request.HttpCategoria
{
    public class HttpCategoriaRepository : IHttpRepository<Categoria>, IHttpRepositoryDTO<CategoriaDTO>
    {
        private readonly HttpClient _httpClient;
        public HttpCategoriaRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Categoria> Atualizar(string id, Categoria objeto)
        {
            try
            {
                var url = $"{id}";

                HttpResponseMessage response = await _httpClient.PutAsJsonAsync<Categoria>(url, objeto);

                var categoria = await response.Content.ReadFromJsonAsync<Categoria>();

                return categoria;

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
        public async Task<Categoria> Cadastrar(Categoria objeto)
        {
            try
            {
                var url = $"";

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Categoria>(url, objeto);

                var categoria = await response.Content.ReadFromJsonAsync<Categoria>();

                return categoria;
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
        public async Task<CategoriaDTO> Buscar(string id)
        {
            try
            {
                var url = $"";

                var categoria = await _httpClient.GetFromJsonAsync<CategoriaDTO>(url);

                return categoria;

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
        public async Task<IEnumerable<CategoriaDTO>> Listar()
        {
            try
            {
                var url = $"https://localhost:7170/api/Categoria/Listar";

                var categorias = await _httpClient.GetFromJsonAsync<IEnumerable<CategoriaDTO>>(url);

                return categorias;

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
