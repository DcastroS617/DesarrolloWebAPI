﻿// <auto-generated />
using System;
using DesarrolloWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesarrolloWebAPI.Migrations
{
    [DbContext(typeof(SQLDbContext))]
    partial class SQLDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesarrolloWebAPI.Archivo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Archivos");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Alimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArchivoId")
                        .HasColumnType("int");

                    b.Property<double>("Precio_Alimento")
                        .HasColumnType("float");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo_Alimento")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Titulo_Alimento")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ArchivoId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Alimentos");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Articulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArchivoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Articulo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Precio_Articulo")
                        .HasColumnType("float");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo_Articulo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ArchivoId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Detalle_Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha_Venta")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total_Ganancia")
                        .HasColumnType("float");

                    b.Property<double>("Total_Venta")
                        .HasColumnType("float");

                    b.Property<int?>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VentaId");

                    b.ToTable("Detalle_Ventas");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlimentoId")
                        .HasColumnType("int");

                    b.Property<int?>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Venta")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlimentoId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Alimento", b =>
                {
                    b.HasOne("DesarrolloWebAPI.Archivo", "Archivo")
                        .WithMany("Alimento")
                        .HasForeignKey("ArchivoId");

                    b.HasOne("DesarrolloWebAPI.Models.Proveedor", "Proveedor")
                        .WithMany("Alimento")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Archivo");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Articulo", b =>
                {
                    b.HasOne("DesarrolloWebAPI.Archivo", "Archivo")
                        .WithMany("Articulo")
                        .HasForeignKey("ArchivoId");

                    b.HasOne("DesarrolloWebAPI.Models.Proveedor", "Proveedor")
                        .WithMany("Articulo")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Archivo");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Detalle_Venta", b =>
                {
                    b.HasOne("DesarrolloWebAPI.Models.Venta", "Venta")
                        .WithMany()
                        .HasForeignKey("VentaId");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Venta", b =>
                {
                    b.HasOne("DesarrolloWebAPI.Models.Alimento", "Alimento")
                        .WithMany("Venta")
                        .HasForeignKey("AlimentoId");

                    b.HasOne("DesarrolloWebAPI.Models.Articulo", "Articulo")
                        .WithMany("Venta")
                        .HasForeignKey("ArticuloId");

                    b.HasOne("DesarrolloWebAPI.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alimento");

                    b.Navigation("Articulo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Archivo", b =>
                {
                    b.Navigation("Alimento");

                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Alimento", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Articulo", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("DesarrolloWebAPI.Models.Proveedor", b =>
                {
                    b.Navigation("Alimento");

                    b.Navigation("Articulo");
                });
#pragma warning restore 612, 618
        }
    }
}