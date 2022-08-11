using CapaAccesoDatosProductos;
using CapaAccesoDatosProductos.Comandos;
using CapaAplicacionProductos.Servicios;
using CapaDominioProductos.DTOs;
using CapaDominioProductos.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_PRODUCTO
{
    [TestFixture]
    public class PrecioProductoTest
    {
        Contexto db;
        GenericsRepository genericsRepository;
        PrecioProductoService precioProductoService;

        [SetUp]
        public void Setup()
        {
            db = new Contexto();
            genericsRepository = new GenericsRepository(db);
            precioProductoService = new PrecioProductoService(genericsRepository);
        }

        [Test]
        public void CrearPrecioProducto()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                var priceProduct = precioProductoService.createPrecioProducto(new PrecioProductoDto { Precioreal = 250, Precioventa = 500, Fecha = DateTime.Now });
                Assert.IsNotNull(priceProduct);
                trans.Rollback();
            }
        }
    }
}
