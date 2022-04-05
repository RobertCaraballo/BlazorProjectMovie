using BlazorAppProjectMovie.Client.Shared.Entidades;

namespace BlazorAppProjectMovie.Client.Repositorios
{
    public interface IRepositorio
    {
        List<Pelicula> GetMovies();

        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
    }
}
