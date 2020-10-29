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
#pragma warning disable CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica. Puede usar el operador 'await' para esperar llamadas API que no sean de bloqueo o 'await Task.Run(...)' para hacer tareas enlazadas a la CPU en un subproceso en segundo plano.
        public async Task<IActionResult> Buscar()
#pragma warning restore CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica. Puede usar el operador 'await' para esperar llamadas API que no sean de bloqueo o 'await Task.Run(...)' para hacer tareas enlazadas a la CPU en un subproceso en segundo plano.
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
