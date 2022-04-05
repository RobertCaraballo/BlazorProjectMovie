using BlazorAppProjectMovie.Client.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorAppProjectMovie.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosControllers : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        public GenerosControllers(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Genero genero)
        {
            applicationDbContext.Add(genero);
            await applicationDbContext.SaveChangesAsync();
            return genero.Id;

        }
    }
}
