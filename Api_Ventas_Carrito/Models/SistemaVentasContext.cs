using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_Ventas_Carrito.Models;

public partial class SistemaVentasContext : DbContext
{
    public SistemaVentasContext()
    {
    }

    public SistemaVentasContext(DbContextOptions<SistemaVentasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Tienda> Tiendas { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Articulo__3214EC073F39EE5B");

            entity.Property(e => e.Codigo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnName("Fecha_Creacion");
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(14, 3)");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC07E4F9AF95");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tienda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tiendas__3214EC075BD9A609");

            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Sucursal)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC076D22FA51");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IsAdmin)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("isAdmin");
            entity.Property(e => e.Password)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ventas__3214EC075CBFD797");

            entity.Property(e => e.CantidadProducto).HasColumnName("Cantidad_Producto");
            entity.Property(e => e.FechaVenta).HasColumnName("Fecha_Venta");
            entity.Property(e => e.TotalVenta)
                .HasColumnType("decimal(14, 3)")
                .HasColumnName("Total_Venta");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
