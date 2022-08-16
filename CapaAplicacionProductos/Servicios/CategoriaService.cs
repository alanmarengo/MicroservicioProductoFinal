using CapaDominioProductos.Comandos;
using CapaDominioProductos.DTOs;
using CapaDominioProductos.Entidades;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CapaAplicacionProductos.Servicios
{
    public interface ICategoriaService
    {
        CategoriaDto createCategoria(string descripcion);
       Categoria actualizarCategoria(int categoriaID, string Descripcion);
    }
    public class CategoriaService :ICategoriaService
    {
        private readonly IGenericsRepository repository;

        public CategoriaService(IGenericsRepository repository)
        {
            this.repository = repository;
        }

        public Categoria actualizarCategoria(int categoriaID, string Descripcion)
        {
            var category = repository.GetBy<Categoria>(categoriaID);
            category.Descripcion = Descripcion;
            return repository.Update(category);
        }

        public CategoriaDto createCategoria(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                return null;
            }

            var entity = new Categoria()
            {
                Descripcion = descripcion
                
            };
            repository.Agregar<Categoria>(entity);
            return new CategoriaDto {Descripcion = entity.Descripcion };
        }
        
    }
}
