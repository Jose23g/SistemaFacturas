using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturas.BL;
using SistemasFacturas.Models;
using System;
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
                return RedirectToAction(nameof(Inventario));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult ModificarProducto(int id)
        {
            Producto productoPorEditar;
            productoPorEditar = repositorioDeProductos.ObtenerProductoPorId(id);
            return View(productoPorEditar);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarProducto (Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorioDeProductos.ModificarProducto(producto);
                    return RedirectToAction(nameof(Inventario));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles ="Administrador")]
        public IActionResult Menu()
        {
            return View();
        }


    }
}
