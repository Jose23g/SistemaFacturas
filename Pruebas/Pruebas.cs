using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaFacturas.BL;
using SistemaFacturas.DA;
using SistemaFacturas.MockPruebas;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebas
{
    [TestClass]
   public class Pruebas
    {


        [TestMethod]
        public void Agregar_Un_Nuevo_Cliente()
        {
            //Arrenge
            Persona persona = new Persona() { Identificacion = 503330333, Nombre = "Lucia", Apellido1 = "Quintanilla", Pais = 1, Provincia = 1, Canton = 1, Distrito = 1, Correo = "miguel@gmail.com", Telefono = "88294975", Tipo = 1 };
            var RepositorioFactura_Falso = new MockRepositorioFactura();

            //Act
            bool respuesta =RepositorioFactura_Falso.AgregarCliente(persona);
            bool Acertado = true;

            //Assert
            Assert.AreEqual(Acertado, respuesta);

        }

        [TestMethod]
        public void Comprovando_consecutivo_Factura()
        {
            //Arrange 
            String ConsecutivoEsperado = "00100001010000000001";
            var RepositorioFactura_Falso = new MockRepositorioFactura();

            //Act
            String ConsecutivoObtenido = RepositorioFactura_Falso.Consecutivo();
           
            //Assert
            Assert.AreEqual(ConsecutivoEsperado, ConsecutivoObtenido);
        }


        [TestMethod]
        public void Corrobar_si_facturar_y_factura_son_lo_mismo()
        {
            //Arrange 
            var RepositorioFactura_Falso = new MockRepositorioFactura();
            Facturar facturar = new Facturar();
            Factura factura = new Factura();
          

            //Act
           


            //Assert
            Assert.AreNotSame(factura, facturar);
        }


        [TestMethod]
        public void Buscar_un_cliente_en_la_lista()
        {
            //Arrange 
            Persona persona1 = new Persona() { Identificacion = 504220984, Nombre = "Jorge", Apellido1 = "Lopez", Pais = 1, Provincia = 1, Canton = 1, Distrito = 1, Correo = "miguel@gmail.com", Telefono = "88294975", Tipo = 1 };
            Persona persona2 = new Persona() { Identificacion = 501110111, Nombre = "Marcos", Apellido1 = "Gonzales", Pais = 1, Provincia = 1, Canton = 1, Distrito = 1, Correo = "miguel@gmail.com", Telefono = "88294975", Tipo = 1 };
            Persona persona3 = new Persona() { Identificacion = 502220222, Nombre = "Lucas", Apellido1 = "Perez", Pais = 1, Provincia = 1, Canton = 1, Distrito = 1, Correo = "miguel@gmail.com", Telefono = "88294975", Tipo = 1 };
            Persona persona4 = new Persona() { Identificacion = 503330333, Nombre = "Lucia", Apellido1 = "Quintanilla", Pais = 1, Provincia = 1, Canton = 1, Distrito = 1, Correo = "miguel@gmail.com", Telefono = "88294975", Tipo = 1 };
            var RepositorioFactura_Falso = new MockRepositorioFactura();

            //Act
            RepositorioFactura_Falso.AgregarCliente(persona1);
            RepositorioFactura_Falso.AgregarCliente(persona2);
            RepositorioFactura_Falso.AgregarCliente(persona3);
            RepositorioFactura_Falso.AgregarCliente(persona4);
            
            Persona personaBuscada = RepositorioFactura_Falso.buscarPersona(504220984);

            //Assert
            Assert.AreEqual(persona1, personaBuscada);
        }



    }
}
