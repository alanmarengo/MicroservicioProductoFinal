using CapaAccesoDatosProductos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_PRODUCTO
{
    public class BaseTEST_PRODUCTO
    {
        Contexto db = null;
        protected Contexto ConstruirContexto()
        {
            if (db==null) 
            {
                var opciones = new DbContextOptionsBuilder<Contexto>().UseSqlServer("Server=DESKTOP-B7GFJSO;Database=productoAPI2;Uid=sa;Pwd='alanabcdA1'",
                options => { }).Options;
                db= new Contexto(opciones);
                return db;
            }
            return db;
        }
    }
}
