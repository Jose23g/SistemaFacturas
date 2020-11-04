using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaFacturas.BL;
using SistemaFacturas.DA;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebas
{
    [TestClass]
   public class PruebaPersona
    {

        [TestMethod]
        public void AnadirUnaPersona()
        {
            RepositorioFactura repositorio = new RepositorioFactura();
            Persona persona = new Persona();
            persona.Nombre = "Jose";
            persona.Apellido1 = "Garcia";
            persona.Identificacion = 504220984;
            persona.Nombre = "Costa Rica";
            persona.Provincia = "Guanacaste";
            persona.Canton = "Carrillo";
            persona.Distrito = "Sarinal";

            bool resultado = true;
            bool actual = repositorio.AgregarCliente(persona);

            Assert.AreEqual(resultado, actual);
          
           // Assert.AreEqual(resultado);
        }
    }
}
