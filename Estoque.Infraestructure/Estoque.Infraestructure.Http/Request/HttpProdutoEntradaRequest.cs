using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Interfaces;
using System.Net.Http.Json;

namespace Estoque.Infraestructure.Http.Request.HttpProdutoEntrada
{
    public class HttpProdutoEntradaRequest : IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO>
    {
        private readonly HttpClient _httpClient;
        public HttpProdutoEntradaRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<ProdutoEntrada> Atualizar(string id, ProdutoEntrada objeto)
        {
            throw new NotImplementedException();
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
        public Task<ProdutoEntrada> Cadastrar(ProdutoEntrada objeto)
        {
            throw new NotImplementedException();
        }
        public Task<string> Deletar(string id)
        {
            throw new NotImplementedException();
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
