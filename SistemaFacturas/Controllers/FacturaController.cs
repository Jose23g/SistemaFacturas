using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SistemaFacturas.BL;
using SistemasFacturas.Models;

namespace SistemaFacturas.Controllers
{
    public class FacturaController : Controller
    {

        private readonly IRepositorioFactura repositorioFactura;
        UserManager<IdentityUser> _userManager;

        public FacturaController(IRepositorioFactura repositorio, UserManager<IdentityUser> userManager)
        {
            repositorioFactura = repositorio;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Facturar()
        {

            ViewData["tipoPago"] = repositorioFactura.MetodoPagos();
            Facturar factura = repositorioFactura.postFactura();
            return View(factura);
        }

        [HttpGet("search")]
        [Produces("application/json")]
        public IActionResult Buscar()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var pstTitle = repositorioFactura.buscar(term);
                return Ok(pstTitle);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Facturar(Facturar facturar)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
        public ActionResult Edit(int id)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
        public ActionResult Delete(int id)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
