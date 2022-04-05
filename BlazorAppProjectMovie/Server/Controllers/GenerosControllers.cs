using Microsoft.AspNetCore.Mvc;

namespace BlazorAppProjectMovie.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosControllers : ControllerBase
    {
        private ApplicationDbContext applicationDbContext { get; }
        public GenerosControllers (ApplicationDbContext applicationDbContext)
        {
            applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Genero genero)
        {
            applicationDbContext.Add(genero);
            await applicationDbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
