using CapaAccesoDatosProductos;
using CapaAccesoDatosProductos.Comandos;
using CapaAplicacionProductos.Servicios;
using CapaDominioProductos.DTOs;
using CapaDominioProductos.Querys;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_PRODUCTO
{
    [TestFixture]
    public class ProductoServiceTest: BaseTEST_PRODUCTO
    {
        Contexto db;
        GenericsRepository genericsRepository;
        ProductoServicio productoServicio;
        Mock<IProductoQuery> _Query;


        [SetUp]
        public void Setup()
        {
            db = ConstruirContexto();
            genericsRepository = new GenericsRepository(db);
            _Query = new Mock<IProductoQuery>();

            _Query.Setup(a => a.GetProductoID(5)).Returns(new ProductoEspecificoDto 
            {
                Imagen="PROYECTO" ,
                Nombre="SOFTWARE",
                Stock=50
            });

            _Query.Setup(a => a.BusquedaProducto(30)).Returns(new List<ProductoDto> { 
                new ProductoDto { Nombre="Proyecto Prueba Producto 1",Descripcion="Es una prueba" }, 
                new ProductoDto { Nombre="Proyecto Prueba Producto 2",Descripcion="Es una prueba"} });

            productoServicio = new ProductoServicio(genericsRepository, _Query.Object);
        }

        [Test]
        public void CrearProducto()
        {
            using (var trans= db.Database.BeginTransaction()) {
                var product = productoServicio.createProducto(new ProductoDto
                {
                    ImagenID = 1,
                    CategoriaID = 1,
                    Stock = 40,
                    Descripcion = "PROYECTO SOFTWARE",
                    MarcaID = 1,
                    Nombre = "Olivera",
                    PrecioID = 1,

                });
                Assert.IsNotNull(product);
                trans.Rollback();
            }
        }


        [Test]
        public void GetProductById()
        {
            var product = productoServicio.GetProductoID(5);
            Assert.IsNotNull(product);
        }


        [Test]
        public void GetProductByIdConIdInvalido()
        {
            var product = productoServicio.GetProductoID(8547);
            Assert.IsNull(product);
        }

        [Test]
        public void BusquedaProductoPrecios()
        {
            var product = productoServicio.BusquedaProducto(30);
            Assert.IsNotNull(product);
        }

        [Test]
        public void BusquedaProductoPreciosConPrecioInexistente()
        {
            var product = productoServicio.BusquedaProducto(30985421);
            Assert.IsNull(product);
        }

    }
}
