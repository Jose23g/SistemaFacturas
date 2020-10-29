using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturas.DA;

namespace SistemaFacturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext contexto;
        public PostController(ApplicationDbContext context)
        {
            contexto = context;
        }

        
        [Produces("application/json")]
        [HttpGet("Buscar")]
        public async Task<IActionResult> Buscar()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var postTitle = contexto.Producto.Where(p => p.Nombre.Contains(term))
                    .Select(p => p.Nombre).ToList();

                return Ok(postTitle);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
