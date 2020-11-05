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
        public void Buscar_Un_Cliente_Registrado()
        {
            //Arrange 
            Persona persona2 = new Persona() { Identificacion = 504220984, Nombre = "Jorge", Apellido1 = "Lopez", Pais = 1, Provincia = 1, Canton = 1, Distrito = 1, Correo = "miguel@gmail.com", Telefono = "88294975", Tipo = 1 };
            var RepositorioFactura_Falso = new MockRepositorioFactura();
            //Act
            Persona resultado = RepositorioFactura_Falso.buscarPersona(persona2.Identificacion);

            //Assert
            Assert.AreEqual(persona2.Identificacion, resultado.Identificacion);
        }

        [TestMethod]
        public void Obtener_Toda_La_Lista_De_Clientes()
        {
            //Arrange 
            Persona persona2 = new Persona() { Identificacion = 504220984, Nombre = "Jorge", Apellido1 = "Lopez", Pais = 1, Provincia = 1, Canton = 1, Distrito = 1, Correo = "miguel@gmail.com", Telefono = "88294975", Tipo = 1 };
            var RepositorioFactura_Falso = new MockRepositorioFactura();
            //Act
            Persona resultado = RepositorioFactura_Falso.buscarPersona(persona2.Identificacion);

            //Assert
            //Assert.pas
        }
    }
}
