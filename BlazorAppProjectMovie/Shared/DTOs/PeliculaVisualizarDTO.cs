using BlazorAppProjectMovie.Client.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppProjectMovie.Shared.DTOs
{
    public class PeliculaVisualizarDTO
    {
        public Pelicula Pelicula { get; set; }
        public int VotoUsuario { get; set; }
        public double PromedioVotos { get; set; }
        public List<Genero> Generos { get; set; }
        public List<Personas> Actores { get; set; }

    }
}
