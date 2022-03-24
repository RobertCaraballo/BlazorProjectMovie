using BlazorAppProjectMovie.Client.Shared.Entidades;

namespace BlazorAppProjectMovie.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public List<Pelicula> GetMovies()
        {
            return new List<Pelicula>
        {
            new Pelicula(){Titulo = "Hola mundo", Fecha_de_lazanmiento = new DateTime(2019, 7, 2)},
            new Pelicula(){Titulo = "Hola mundo", Fecha_de_lazanmiento = new DateTime(2019, 7, 2)},
            new Pelicula(){Titulo = "Hola mundo", Fecha_de_lazanmiento = new DateTime(2019, 7, 2)},
            new Pelicula(){Titulo = "Hol mundo", Fecha_de_lazanmiento = new DateTime(2019, 7, 2)}
        };
        }
    }
}
