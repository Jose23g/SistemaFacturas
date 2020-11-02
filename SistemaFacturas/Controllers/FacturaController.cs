using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
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

        public FacturaController(IRepositorioFactura repositorio, UserManager<IdentityUser> userManager, IRepositorioDeProductos repositorioDeProductos, ApplicationDbContext context)
        {
            repositorioFactura = repositorio;
            repositorioDeProductos1 = repositorioDeProductos;
            contexto = context;
            _userManager = userManager;

        }

        public async Task<IActionResult> Facturar()
        {

            ViewData["tipoPago"] = repositorioFactura.MetodoPagos();
            ViewBag.Productos = await contexto.Producto.Select(x=> new {x.Cod_producto, x.Nombre}).ToListAsync();

            Facturar model = new Facturar();
            ViewData["lisProducto"] = productos;
           
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
            catch(Exception ex)
            {
                return View();
            }
        }


        // GET: HomeController1/Create
        public ActionResult NuevaFactura()
        {
            Facturar facturar = new Facturar();
            List<Producto> listaProductos = new List<Producto>();
            ViewData["tipoPago"] = repositorioFactura.MetodoPagos();           
            facturar.producto = listaProductos;
            return View(facturar);
        }

        // POST: HomeController1/Create
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
            catch
            {
                return View();
            }
        }
        // GET: HomeController1/Create
        public ActionResult Lista()
        {
            ViewData["tipoPago"] = repositorioFactura.MetodoPagos();
            return View();
        }


        private static List<string> l_indices = new List<string>();
        private static List<Detalle> detalles = new List<Detalle>();
        private static List<string> l_alumnos = new List<string>();
       

        public JsonResult buscar(string dato_bus, int cantidad)
        {
            var producto = new List<Producto>();
            producto = repositorioFactura.bus_atr(dato_bus, cantidad);
            return Json(producto);
        }

        //--------busqueda de alumno
        [HttpPost]
        public String bus_atr(string dato_bus, int cantidad)
        {
            string res = "";
            var producto = new List<Producto>();
            producto = repositorioFactura.bus_atr(dato_bus, cantidad);
            


            foreach (var a in producto)
            {
                int codProducto = a.Cod_producto;
                string nombreProducto = a.Nombre;
                string detalleProducto = a.Detalle;
                int precioProducto = (int)a.Precio;
                int disponibles = a.Cantidad;
                int Cantidad = cantidad;
               
                if (repositorioFactura.Disponible(codProducto, cantidad) >= cantidad)
                {
                   
                    string boton_sel = "<button class=\"btn btn-warning\" type='button'"
                        + " onclick=\"agr_atr('" + codProducto + "','" + nombreProducto + "','" + detalleProducto + "','" + precioProducto + "','" + Cantidad + "')\""
                        + " data-dismiss='modal'><span class=\"glyphicon glyphicon-check\"> Añadir</span></button>";
                    res = res +
                        "<tr>" 
                        +"<td>" + codProducto + "</td>"
                        + "<td>" + nombreProducto + "</td>"
                        + "<td>" + detalleProducto + "</td>"
                        + "<td>" + precioProducto + "</td>"
                        + "<td>" + disponibles + "</td>"
                        + "<td>" + boton_sel + "</td></tr>";
                }
                else
                {
                    string boton_sel = "<button><span class=\"glyphicon glyphicon-check\"> No disponible</span></button>";
                    res = res +
                        "<tr>"
                        + "<td>" + codProducto + "</td>"
                        + "<td>" + nombreProducto + "</td>"
                        + "<td>" + detalleProducto + "</td>"
                        + "<td>" + precioProducto + "</td>"
                        + "<td>" + disponibles + "</td>"
                        + "<td>" + boton_sel + "</td></tr>";
                }

               
            }
            return res;
        }
       
        public JsonResult agregar(string codProducto, string nombreProducto, string detalleProducto, string precioProducto, int cantidad, int cantidadSelecionada)
        {
            Detalle detalle = new Detalle();
            Producto producto = repositorioDeProductos1.ObtenerProductoPorId(int.Parse(codProducto));
            
            producto.CantidadSelecionada = cantidadSelecionada;
            detalle.Cod_producto = int.Parse(codProducto);
            detalle.Cantidad = cantidad;
           
            if(listaProductos.Count == 0) 
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
                        if(item.Cod_producto == listaProductos.Last().Cod_producto)
                        {
                            listaDetalle.Insert(0, detalle);
                            listaProductos.Insert(0,producto);
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

        //------------Agregar Alumno 
        public String agr_atr(string codProducto, string nombreProducto, string detalleProducto, string precioProducto, int Cantidad)
        {
            string res = "";
            int cont = 0;
            Detalle detalle = new Detalle();
            detalle.Cod_producto = int.Parse(codProducto);
            detalle.Cantidad = Cantidad;

            foreach (var w in l_indices)
            {
                if (w.Equals(codProducto))
                {
                    cont++;
                }
            }
            if (cont == 0)
            {
                if (l_alumnos.Count < 8)
                {
                    string boton_bor = "<button class=\"btn btn-danger\" type='button'"
                        + " onclick=\"bor_atr('" + codProducto + "')\""
                        + "><span class=\"glyphicon glyphicon-trash\"> Borrar</span></button>"; //--Esta variable boton_bor representa un boton
                    l_alumnos.Add(
                        "<tr><td>" + codProducto + "</td>"
                        + "<td>" + nombreProducto + "</td>"
                        + "<td>" + detalleProducto + "</td>"
                        + "<td>" + precioProducto + "</td>"
                        + "<td>" + Cantidad + "</td>"
                        + "<td>" + boton_bor + "</td></tr>"
                        );
                    l_indices.Add(codProducto);
                    detalles.Add(detalle);
                }
            }
            foreach (var a in l_alumnos)
            {
                res = res + a;
            }
            return res;
        }

        //--------------Limpieza--------------------
        [HttpPost]
        public void limpiar_atr()
        {
            l_alumnos.Clear();
            l_indices.Clear();
        }
        
        //-------------- Borrar Alumno de Lista -----------
        public String bor_atr(string id)
        {
            
            string res = "";
            l_alumnos.RemoveAt(l_indices.IndexOf(id));
            l_indices.RemoveAt(l_indices.IndexOf(id));
            foreach (var a in l_alumnos)
            {
                res = res + a;
            }
            return res;
        }

    }
}

