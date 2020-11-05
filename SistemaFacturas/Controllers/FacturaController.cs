using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaFacturas.BL;
using SistemaFacturas.DA;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturas.Controllers
{
    public class FacturaController : Controller
    {

        private readonly IRepositorioFactura repositorioFactura;
        private readonly IRepositorioDeProductos repositorioDeProductos1;
        private readonly ApplicationDbContext contexto;
        Response res = new Response();
        UserManager<IdentityUser> _userManager;
        List<Producto> productos = new List<Producto>();

        private static List<Producto> listaProductos = new List<Producto>();
        private static List<Detalle> listaDetalle = new List<Detalle>();
        private static List<string> l_indices = new List<string>();
        private static List<Detalle> detalles = new List<Detalle>();
        private static List<string> l_alumnos = new List<string>();

        public FacturaController(IRepositorioFactura repositorio, UserManager<IdentityUser> userManager, IRepositorioDeProductos repositorioDeProductos, ApplicationDbContext context)
        {
            repositorioFactura = repositorio;
            repositorioDeProductos1 = repositorioDeProductos;
            contexto = context;
            _userManager = userManager;

        }

        public async Task<IActionResult> Facturar(int id)
        {

            ViewData["tipoPago"] = repositorioFactura.MetodoPagos();
            ViewBag.Productos = await contexto.Producto.Select(x => new { x.Cod_producto, x.Nombre }).ToListAsync();

            Facturar model = new Facturar();
            Persona persona = repositorioFactura.buscarPersona(id);
            Factura factura = new Factura();

            factura.Identificacion = persona.Identificacion;
            factura.Nombre = persona.Nombre + " " + persona.Apellido1;
            factura.FechaEmision = DateTime.Today;
            
            model.Factura = factura;

            ViewData["lisProducto"] = productos;
            listaDetalle.Clear();
            listaProductos.Clear();
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Facturar(Facturar facturar)
        {
            try
            {
                facturar.producto = listaProductos;
                facturar.Detalle = listaDetalle;
                repositorioFactura.AgregarFactura(facturar);

                return RedirectToAction(nameof(Facturar));
            }
            catch (Exception ex)
            {
                return View();
            }
        }



        public ActionResult NuevaFactura()
        {
            Facturar facturar = new Facturar();
            List<Producto> listaProductos = new List<Producto>();
            ViewData["tipoPago"] = repositorioFactura.MetodoPagos();
            facturar.producto = listaProductos;
            return View(facturar);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevaFactura(Facturar facturar)
        {
            try
            {
                repositorioFactura.AgregarFactura(facturar);
                return RedirectToAction(nameof(NuevaFactura));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult ListaClientes()
        {
            List<Persona> listaClientes;
            listaClientes = repositorioFactura.ListaClientes();
            return View(listaClientes);
        }


        public ActionResult NuevoCliente()
        {

            ViewData["tipoIdentificacion"] = repositorioFactura.TipoIdentificacion();
            ViewBag.Pais = repositorioFactura.listaPais();
            ViewBag.Provincia = repositorioFactura.listaProvincia();
            ViewBag.Canton = repositorioFactura.listaCanton();
            ViewBag.Distrito = repositorioFactura.listaDistito();
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoCliente(Persona cliente)
        {
            try
            {
                repositorioFactura.AgregarCliente(cliente);
                return RedirectToAction(nameof(ListaClientes));
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public ActionResult Lista()
        {
            ViewData["tipoPago"] = repositorioFactura.MetodoPagos();
            return View();
        }


        public JsonResult buscar(string dato_bus, int cantidad)
        {
            var producto = new List<Producto>();
            producto = repositorioFactura.bus_atr(dato_bus, cantidad);
            return Json(producto);
        }


        public JsonResult agregar(string codProducto, string nombreProducto, string detalleProducto, string precioProducto, int cantidad, int cantidadSelecionada)
        {
            Detalle detalle = new Detalle();
            Producto producto = repositorioDeProductos1.ObtenerProductoPorId(int.Parse(codProducto));

            producto.CantidadSelecionada = cantidadSelecionada;
            detalle.Cod_producto = int.Parse(codProducto);
            detalle.Cantidad = cantidadSelecionada;

            if (listaProductos.Count == 0)
            {
                producto.Cantidad = repositorioDeProductos1.disminuirCantidad(int.Parse(codProducto), cantidadSelecionada).Cantidad;
                listaDetalle.Add(detalle);
                listaProductos.Add(producto);

            }
            else
            {
                foreach (Producto item in listaProductos)
                {
                    if (item.Cod_producto == int.Parse(codProducto))
                    {
                        item.CantidadSelecionada += 1;
                        item.Cantidad = repositorioDeProductos1.disminuirCantidad(int.Parse(codProducto), cantidadSelecionada).Cantidad;

                        foreach (var item2 in listaDetalle)
                        {
                            if (item2.Cod_producto == item.Cod_producto)
                            {
                                item2.Cantidad += 1;
                                break;
                            }
                        }
                        break;
                    }
                    else
                    {
                        if (item.Cod_producto == listaProductos.Last().Cod_producto)
                        {
                            listaDetalle.Insert(0, detalle);
                            listaProductos.Insert(0, producto);
                            item.Cantidad = repositorioDeProductos1.disminuirCantidad(int.Parse(codProducto), cantidadSelecionada).Cantidad;
                            break;
                        }
                    }
                }
            }
            return Json(listaProductos);
        }

        public JsonResult borrar(int id, int cantidad)
        {
            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (listaProductos[i].Cod_producto == id)
                {
                    listaProductos.RemoveAt(i);
                    repositorioDeProductos1.aumentarCantidad(id, cantidad);

                }
            }

            for (int j = 0; j < listaDetalle.Count; j++)
            {
                if (listaDetalle[j].Cod_producto == id)
                {
                    listaDetalle.RemoveAt(j);
                }
            }

            return Json(listaProductos);
        }

        public JsonResult RecargarProvincia(string Id_provincia)
        {
            List<Provincia> provincias = repositorioFactura.provincias(Id_provincia);
            ViewBag.Provincias = new SelectList(provincias, "Id_pais", "Id_provincia", "Nombre_provincia");

            return Json(provincias);
        }

        public JsonResult RecargarCanton(string Id_Canton)
        {
            List<Canton> cantones = repositorioFactura.cantones(Id_Canton);
            ViewBag.Cantones = new SelectList(cantones, "Id_pais", "Id_provincia", "Id_canton", "Nombre_canton");

            return Json(cantones);
        }
        public JsonResult RecargarDistrito(string Id_Distrito)
        {
            List<Distrito> distritos = repositorioFactura.distritos(Id_Distrito);
            ViewBag.Cantones = new SelectList(distritos, "Id_provincia", "Id_canton", "Id_distrito", "Nombre_distrito");

            return Json(distritos);
        }
    }

   
}