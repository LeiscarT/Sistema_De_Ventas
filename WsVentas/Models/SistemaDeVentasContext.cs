using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WsVentas.Models
{
    public partial class SistemaDeVentasContext : DbContext
    {
        public SistemaDeVentasContext()
        {
        }

        public SistemaDeVentasContext(DbContextOptions<SistemaDeVentasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ConceptoVentum> ConceptoVenta { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<VentasCliente> VentasClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-VCDF4F5;Database=SistemaDeVentas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ConceptoVentum>(entity =>
            {
                entity.ToTable("conceptoVenta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.Importe)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("importe");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("precioUnitario");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ConceptoVenta)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_conceptoVenta_producto");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.ConceptoVenta)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_conceptoVenta_VentasCliente");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Costo)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("costo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("precioUnitario");
            });

            modelBuilder.Entity<VentasCliente>(entity =>
            {
                entity.ToTable("VentasCliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.VentasClientes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentasCliente_cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
