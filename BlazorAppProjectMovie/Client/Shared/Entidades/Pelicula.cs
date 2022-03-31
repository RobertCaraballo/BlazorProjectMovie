namespace BlazorAppProjectMovie.Client.Shared.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; } 
        public string Titulo { get; set; }

        public string Resumen { get; set; }

        public bool EnCartelera { get; set; }

        public string Trailer { get; set; }
        
        public DateTime Fecha_de_lazanmiento { get; set; }

        public string Poster { get; set; }
    }
}