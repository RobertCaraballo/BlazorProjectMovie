using System.ComponentModel.DataAnnotations;

namespace BlazorAppProjectMovie.Client.Shared.Entidades
{
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requiro para proceder")]
        public string Name { get; set; }

        public List<GeneroPelicula> GeneroPeliculas { get; set; }
    }
}
