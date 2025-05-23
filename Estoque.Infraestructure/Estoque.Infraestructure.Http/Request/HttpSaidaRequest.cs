﻿using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Interfaces;
using System.Net.Http.Json;

namespace Estoque.Infraestructure.Http.Request.HttpSaida
{
    public class HttpSaidaRequest : IHttpRepository<Saida, SaidaDTO>
    {
        private readonly HttpClient _httpClient;
        public HttpSaidaRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Saida> Atualizar(string id, Saida objeto)
        {
            try
            {
                var url = $"{id}";

                HttpResponseMessage response = await _httpClient.PutAsJsonAsync(url, objeto);

                var Saida = await response.Content.ReadFromJsonAsync<Saida>();

                return Saida;

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
        public async Task<Saida> Cadastrar(Saida objeto)
        {
            try
            {
                var url = $"";

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, objeto);

                var Saida = await response.Content.ReadFromJsonAsync<Saida>();

                return Saida;
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
        public async Task<SaidaDTO> Buscar(string id)
        {
            try
            {
                var url = $"";

                var Saida = await _httpClient.GetFromJsonAsync<SaidaDTO>(url);

                return Saida;

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
        public async Task<IEnumerable<SaidaDTO>> Listar()
        {
            try
            {
                var url = $"";

                var Saidas = await _httpClient.GetFromJsonAsync<IEnumerable<SaidaDTO>>(url);

                return Saidas;

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
