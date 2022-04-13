using BlazorAppProjectMovie.Client.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace BlazorAppProjectMovie.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient httpClient;

        public Repositorio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private JsonSerializerOptions OpcionPorDefectoJson => new() { PropertyNameCaseInsensitive = true };

        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {

                var response = await DeserializarRespuesta<T>(responseHTTP, OpcionPorDefectoJson);
                return new HttpResponseWrapper<T>(response, false, responseHTTP);

            }else
            {
                return new HttpResponseWrapper<T>(default, true, responseHTTP);
            }

        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);

            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<TResponse>(responseHttp, OpcionPorDefectoJson);

                return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
                //return new HttpResponseWrapper<TResponse>();
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(default, true, responseHttp);
            }

            //return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        }
        public List<Pelicula> GetMovies()
        {
                return new List<Pelicula>
            {
                new Pelicula(){Titulo = "Los negros", Fecha_de_lazanmiento = new DateTime(2019, 7, 2), Poster = "https://pics.filmaffinity.com/los_negros-999805830-mmed.jpg"},
                new Pelicula(){Titulo = "Sonic 2", Fecha_de_lazanmiento = new DateTime(2019, 7, 2),Poster = "https://pics.filmaffinity.com/sonic_the_hedgehog_2-126622695-mmed.jpg"},
                new Pelicula(){Titulo = "Belle", Fecha_de_lazanmiento = new DateTime(2019, 7, 2), Poster = "https://pics.filmaffinity.com/ryu_to_sobakasu_no_hime-275212334-mmed.jpg"},
                new Pelicula(){Titulo = "La cima", Fecha_de_lazanmiento = new DateTime(2019, 7, 2), Poster = "https://pics.filmaffinity.com/la_cima-811439843-mmed.jpg"}
            };
        }
    }
}
