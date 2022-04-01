using BlazorAppProjectMovie.Client.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppProjectMovie.Shared.Entidades
{
    public class PeliculaActor
    {
        public int PersonaId { get; set; }
        public int PeliculaId { get; set; }

        public Personas Persona { get; set; }

        public Pelicula Pelicula { get; set; }

        public string Personaje { get; set; }

        public int Orden { get; set; }
    }
}
