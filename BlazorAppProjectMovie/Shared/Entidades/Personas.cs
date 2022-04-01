using BlazorAppProjectMovie.Shared.Entidades;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppProjectMovie.Client.Shared.Entidades
{
    public class Personas
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Biografia { get; set; }

        public string Foto { get; set; }

        [Required]
        public DateTime? FechaNacimiento { get; set; }

        public List<PeliculaActor> PeliculasActor { get; set; }
    }
}
