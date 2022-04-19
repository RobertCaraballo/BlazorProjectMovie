using BlazorAppProjectMovie.Client.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace BlazorAppProjectMovie.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personas>>> Get()
        {
            return await context.Personas.ToListAsync();
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Personas>>> Get(string textoBusqueda)
        {
            if(string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Personas>(); }
            textoBusqueda = textoBusqueda.ToLower();
            return await context.Personas.Where(x => x.Nombre.ToLower().Contains(textoBusqueda)).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Personas persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return persona.Id;
        }
    }


}
