using CapaAccesoDatosProductos;
using CapaAccesoDatosProductos.Comandos;
using CapaAplicacionProductos.Servicios;
using CapaDominioProductos.DTOs;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_PRODUCTO
{
    [TestFixture]
    public class MarcaServiceTest:BaseTEST_PRODUCTO
    {
        Contexto db;
        GenericsRepository genericsRepository;
        MarcaService marcaService;


        [SetUp]
        public void Setup()
        {
            db = ConstruirContexto();
            genericsRepository = new GenericsRepository(db);
            marcaService = new MarcaService(genericsRepository);
        }

        [Test]
        public void CrearMarca()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                var tradeMark = marcaService.createMarca(new MarcaDto { Nombre = "Proyecto Sofwtare" });
                Assert.IsNotNull(tradeMark);
                trans.Rollback();
            }
        }
    }
}
