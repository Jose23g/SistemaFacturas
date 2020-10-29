using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturas.BL;
using SistemasFacturas.Models;
using System.Collections.Generic;

namespace SistemaFacturas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioDeProductos repositorioDeProductos;

        public HomeController(IRepositorioDeProductos repositorio)
        {
            repositorioDeProductos = repositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Inventario()
        {
            List<Producto> laListaDeProductos;
            laListaDeProductos = repositorioDeProductos.ListaDeProductos();
            return View(laListaDeProductos);
        }

        // GET: HomeController1/Create
        public ActionResult NuevoProducto()
        {
            ViewData["categorias"] = repositorioDeProductos.ListaDeCategoria();
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoProducto(Producto producto)
        {
            try
            {
                repositorioDeProductos.AgregarProductos(producto);
                return RedirectToAction(nameof(Menu));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles ="Recursos Humanos")]
        public IActionResult Menu()
        {
            return View();
        }


    }
}
