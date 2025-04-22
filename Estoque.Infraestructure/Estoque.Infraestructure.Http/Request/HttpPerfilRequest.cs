using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Interfaces;
using System.Net.Http.Json;

namespace Estoque.Infraestructure.Http.Request.HttpPerfil
{
    public class HttpPerfilRequest : IHttpRepository<Perfil, PerfilDTO>
    {
        private readonly HttpClient _httpClient;
        public HttpPerfilRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Perfil> Atualizar(string id, Perfil objeto)
        {
            try
            {
                var url = $"{id}";

                HttpResponseMessage response = await _httpClient.PutAsJsonAsync(url, objeto);

                var Perfil = await response.Content.ReadFromJsonAsync<Perfil>();

                return Perfil;

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
        public async Task<Perfil> Cadastrar(Perfil objeto)
        {
            try
            {
                var url = $"";

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, objeto);

                var Perfil = await response.Content.ReadFromJsonAsync<Perfil>();

                return Perfil;
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
        public async Task<PerfilDTO> Buscar(string id)
        {
            try
            {
                var url = $"";

                var Perfil = await _httpClient.GetFromJsonAsync<PerfilDTO>(url);

                return Perfil;

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
        public async Task<IEnumerable<PerfilDTO>> Listar()
        {
            try
            {
                var url = $"https://localhost:7170/api/Perfil/Listar";

                var Perfils = await _httpClient.GetFromJsonAsync<IEnumerable<PerfilDTO>>(url);

                return Perfils;

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
