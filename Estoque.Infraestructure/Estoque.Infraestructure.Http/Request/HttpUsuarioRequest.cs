using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Interfaces;
using System.Net.Http.Json;

namespace Estoque.Infraestructure.Http.Request.HttpUsuario
{
    public class HttpUsuarioRequest : IHttpRepository<Usuario, UsuarioDTO>
    {
        private readonly HttpClient _httpClient;
        public HttpUsuarioRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Usuario> Atualizar(string id, Usuario objeto)
        {
            try
            {
                var url = $"{id}";

                HttpResponseMessage response = await _httpClient.PutAsJsonAsync(url, objeto);

                var Usuario = await response.Content.ReadFromJsonAsync<Usuario>();

                return Usuario;

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
        public async Task<Usuario> Cadastrar(Usuario objeto)
        {
            try
            {
                var url = $"";

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, objeto);

                var Usuario = await response.Content.ReadFromJsonAsync<Usuario>();

                return Usuario;
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
        public async Task<UsuarioDTO> Buscar(string id)
        {
            try
            {
                var url = $"";

                var Usuario = await _httpClient.GetFromJsonAsync<UsuarioDTO>(url);

                return Usuario;

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
        public async Task<IEnumerable<UsuarioDTO>> Listar()
        {
            try
            {
                var url = $"https://localhost:7170/api/Usuario/Listar";

                var Usuarios = await _httpClient.GetFromJsonAsync<IEnumerable<UsuarioDTO>>(url);

                return Usuarios;

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
