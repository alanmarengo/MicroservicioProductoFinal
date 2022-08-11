using CapaAccesoDatosProductos;
using CapaAccesoDatosProductos.Comandos;
using CapaAplicacionProductos.Servicios;
using CapaDominioProductos.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_PRODUCTO
{
    [TestFixture]
    public class CategoriaServiceTest
    {
        Contexto db;
        GenericsRepository genericsRepository;
        CategoriaService categoriaService;

        [SetUp]
        public void Setup()
        {
            db = new Contexto();
            genericsRepository = new GenericsRepository(db);
            categoriaService = new CategoriaService(genericsRepository);
        }


        [Test]
        public void CrearCategoria()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                var category = categoriaService.createCategoria("proyecto software");
                Assert.IsNotNull(category);
                trans.Rollback();
            }

        }

        [Test]
        public void UpdateCategoria()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                var sale = categoriaService.actualizarCategoria(4, "Proyecto software 2");
                Assert.IsNotNull(sale);
                trans.Rollback();
            }
        }

    }
}
