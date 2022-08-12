using CapaAccesoDatosProductos;
using CapaAccesoDatosProductos.Comandos;
using CapaAplicacionProductos.Servicios;
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
    public class CategoriaServiceTest: BaseTEST_PRODUCTO
    {
        Contexto db;
        GenericsRepository genericsRepository;
        CategoriaService categoriaService;

        [SetUp]
        public void Setup()
        {
            db = ConstruirContexto();
            genericsRepository = new GenericsRepository(db);
            categoriaService = new CategoriaService(genericsRepository);
        }


        [Test]
        public void CrearCategoria()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                var category = categoriaService.createCategoria("proyecto software");
                NUnit.Framework.Assert.IsNotNull(category);
                trans.Rollback();
            }

        }

        [Test]
        public void UpdateCategoria()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                var sale = categoriaService.actualizarCategoria(4, "Proyecto software 2");
                NUnit.Framework.Assert.IsNotNull(sale);
                trans.Rollback();
            }
        }


        [Test]
        [ExpectedException(typeof(FormatException))]
        public void UpdateCategoriaConIdCategoriaInvalido()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                try
                {
                    var sale = categoriaService.actualizarCategoria(int.Parse("PROYECTO"), "Proyecto software 2");
                }
                catch (Exception ex)
                {

                }

            }
        }

    }
}
