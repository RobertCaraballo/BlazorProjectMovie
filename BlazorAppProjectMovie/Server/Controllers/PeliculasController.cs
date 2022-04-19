using BlazorAppProjectMovie.Client.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorAppProjectMovie.Shared.DTOs;

namespace BlazorAppProjectMovie.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PeliculasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<HomePageDTO>> Get()
        {
            var limite = 6;

            var peliculasEnCartelera = await context.Peliculas.Where(x => x.EnCartelera).Take(limite)
                                                              .OrderByDescending(x => x.Fecha_de_lazanmiento)
                                                              .ToListAsync();
            var fechaActual = DateTime.Today;

            var proximosEstrenos = await context.Peliculas.Where(x => x.Fecha_de_lazanmiento > fechaActual)
                .OrderBy(x => x.Fecha_de_lazanmiento).Take(limite)
                .ToListAsync();

            var responde = new HomePageDTO()
            {
                PeliculasEnCartelera = peliculasEnCartelera,
                ProximosEstrenos = proximosEstrenos
            };
            return responde;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PeliculaVisualizarDTO>> Get(int id)
        {
            var pelicula = await context.Peliculas.Where(x => x.Id == id)
                                                  .Include(x => x.GeneroPelicula).ThenInclude(x => x.Genero)
                                                  .Include(x => x.PeliculaActors).ThenInclude(x => x.Persona)
                                                  .FirstOrDefaultAsync();

            if (pelicula == null) { return NotFound(); }

            var promedioVotos = 4;

            var votoUsuario = 5;

            pelicula.PeliculaActors = pelicula.PeliculaActors.OrderBy(x => x.Orden).ToList();

            var model = new PeliculaVisualizarDTO();
            model.Pelicula = pelicula;
            model.Generos = pelicula.GeneroPelicula.Select(x => x.Genero).ToList();

            model.Actores = pelicula.PeliculaActors.Select(x =>
            new Personas
            {
                Nombre = x.Persona.Nombre,
                Foto = x.Persona.Foto,
                Personaje = x.Persona.Personaje,
                Id = x.Persona.Id,
            }).ToList();

            model.PromedioVotos = promedioVotos;
            model.VotoUsuario = votoUsuario;
            return model;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Pelicula pelicula)
        {
            if (!string.IsNullOrWhiteSpace(pelicula.Poster))
            {
                var fotoPersona = Convert.FromBase64String(pelicula.Poster);
            }

            if (pelicula.PeliculaActors != null)
            {
                for (int i = 0; i < pelicula.PeliculaActors.Count; i++)
                {
                    pelicula.PeliculaActors[i].Orden = i + 1;
                }
            }

            context.Add(pelicula);
            await context.SaveChangesAsync();
            return pelicula.Id;
        }
    }
}
