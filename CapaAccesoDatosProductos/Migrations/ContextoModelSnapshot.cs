﻿// <auto-generated />
using System;
using CapaAccesoDatosProductos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CapaAccesoDatosProductos.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CapaDominioProductos.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("CapaDominioProductos.Entidades.ImagenProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("imagenproducto");
                });

            modelBuilder.Entity("CapaDominioProductos.Entidades.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("marca");
                });

            modelBuilder.Entity("CapaDominioProductos.Entidades.PrecioProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Precioreal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Precioventa")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("precioproducto");
                });

            modelBuilder.Entity("CapaDominioProductos.Entidades.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImagenID")
                        .HasColumnType("int");

                    b.Property<int?>("ImagenProductoNavigatorId")
                        .HasColumnType("int");

                    b.Property<int>("MarcaID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrecioID")
                        .HasColumnType("int");

                    b.Property<int?>("PrecioProductoNavigatorId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("ImagenProductoNavigatorId");

                    b.HasIndex("MarcaID");

                    b.HasIndex("PrecioProductoNavigatorId");

                    b.ToTable("productos");
                });

            modelBuilder.Entity("CapaDominioProductos.Entidades.Producto", b =>
                {
                    b.HasOne("CapaDominioProductos.Entidades.Categoria", "CategoriaNavigator")
                        .WithMany()
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CapaDominioProductos.Entidades.ImagenProducto", "ImagenProductoNavigator")
                        .WithMany()
                        .HasForeignKey("ImagenProductoNavigatorId");

                    b.HasOne("CapaDominioProductos.Entidades.Marca", "MarcaNavigator")
                        .WithMany()
                        .HasForeignKey("MarcaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CapaDominioProductos.Entidades.PrecioProducto", "PrecioProductoNavigator")
                        .WithMany()
                        .HasForeignKey("PrecioProductoNavigatorId");
                });
#pragma warning restore 612, 618
        }
    }
}
