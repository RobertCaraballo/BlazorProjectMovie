 using BlazorAppProjectMovie.Client.Shared.Entidades;

namespace BlazorAppProjectMovie.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
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
