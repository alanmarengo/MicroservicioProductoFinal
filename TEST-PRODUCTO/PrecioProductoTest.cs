using CapaAccesoDatosProductos;
using CapaAccesoDatosProductos.Comandos;
using CapaAplicacionProductos.Servicios;
using CapaDominioProductos.DTOs;
using CapaDominioProductos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_PRODUCTO
{
    [TestFixture]
    public class PrecioProductoTest:BaseTEST_PRODUCTO
    {
        Contexto db;
        GenericsRepository genericsRepository;
        PrecioProductoService precioProductoService;

        [SetUp]
        public void Setup()
        {
            db =ConstruirContexto();
            genericsRepository = new GenericsRepository(db);
            precioProductoService = new PrecioProductoService(genericsRepository);
        }

        [Test]
        public void CrearPrecioProducto()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                var priceProduct = precioProductoService.createPrecioProducto(new PrecioProductoDto { Precioreal = 250, Precioventa = 500, Fecha = DateTime.Now });
                NUnit.Framework.Assert.IsNotNull(priceProduct);
                trans.Rollback();
            }
        }



        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CrearPrecioProductoInvalido()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                try
                {
                    var priceProduct = precioProductoService.createPrecioProducto(null);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
