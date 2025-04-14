using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Interface;
using System.Net.Http.Json;

namespace Estoque.Infraestructure.Http.Request.HttpEntrada
{
    public class HttpEntradaRepository : IHttpRepository<Entrada>, IHttpRepositoryDTO<EntradaDTO>
    {
        private readonly HttpClient _httpClient;
        public HttpEntradaRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Entrada> Atualizar(string id, Entrada objeto)
        {
            try
            {
                var url = $"{id}";

                HttpResponseMessage response = await _httpClient.PutAsJsonAsync(url, objeto);

                var Entrada = await response.Content.ReadFromJsonAsync<Entrada>();

                return Entrada;

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
        public async Task<Entrada> Cadastrar(Entrada objeto)
        {
            try
            {
                var url = $"";

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, objeto);

                var Entrada = await response.Content.ReadFromJsonAsync<Entrada>();

                return Entrada;
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
        public async Task<EntradaDTO> Buscar(string id)
        {
            try
            {
                var url = $"";

                var Entrada = await _httpClient.GetFromJsonAsync<EntradaDTO>(url);

                return Entrada;

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
        public async Task<IEnumerable<EntradaDTO>> Listar()
        {
            try
            {
                var url = $"";

                var Entradas = await _httpClient.GetFromJsonAsync<IEnumerable<EntradaDTO>>(url);

                return Entradas;

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
