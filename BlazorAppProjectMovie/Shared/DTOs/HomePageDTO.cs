﻿using BlazorAppProjectMovie.Client.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppProjectMovie.Shared.DTOs
{
    public class HomePageDTO
    {
        public List<Pelicula> PeliculasEnCartelera { get; set; }
        public List<Pelicula> ProximosEstrenos { get; set; }

    }
}
