using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturas.BL;
using SistemasFacturas.Models;

namespace SistemaFacturas.Controllers
{
    public class ReporteController : Controller
    {
        private readonly IRepositorioFactura repositorioFactura;

        public ReporteController(IRepositorioFactura repositorio)
        {
            repositorioFactura = repositorio;
        }


        public ActionResult Reportes()
        {
            try
            {
                List<Reporte> listaReporte = repositorioFactura.reportes();
                return View(listaReporte);
            }
            catch (Exception ex)
            {
                return View();
            }
           
        }

       
        public ActionResult index()
        {
            List<Factura> listaFacturas = repositorioFactura.facturas();
            return View(listaFacturas);
        }

    }
}
