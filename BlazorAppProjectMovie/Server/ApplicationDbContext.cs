using BlazorAppProjectMovie.Client.Shared.Entidades;
using BlazorAppProjectMovie.Shared.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppProjectMovie.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneroPelicula>().HasKey(e => new {e.GeneroId, e.PeliculaId });
            modelBuilder.Entity<PeliculaActor>().HasKey(x => new { x.PeliculaId, x.PersonaId });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GeneroPelicula> GenerosPeliculas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<PeliculaActor> PeliculaActors { get; set; }

    }
}
