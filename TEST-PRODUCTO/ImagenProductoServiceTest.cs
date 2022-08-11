using CapaAccesoDatosProductos;
using CapaAccesoDatosProductos.Comandos;
using CapaAplicacionProductos.Servicios;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_PRODUCTO
{
    [TestFixture]
    class ImagenProductoServiceTest: BaseTEST_PRODUCTO
    {
        Contexto db;
        GenericsRepository genericsRepository;
        ImagenProductoService imagenProductoService;

        [SetUp]
        public void Setup()
        {
            db = ConstruirContexto();
            genericsRepository = new GenericsRepository(db);
            imagenProductoService = new ImagenProductoService(genericsRepository);
        }


        [Test]
        public void CrearImagenProducto()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                var image = imagenProductoService.createImagenProducto("proyectosoftware");
                Assert.IsNotNull(image);
                trans.Rollback();
            }
        }
    }
}
