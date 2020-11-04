using Microsoft.AspNetCore.Mvc;
using SistemaFacturas.BL;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;

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
