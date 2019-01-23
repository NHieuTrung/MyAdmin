using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models.Models
{
    public partial class MyCoreAdminDBContext : DbContext
    {
        public MyCoreAdminDBContext()
        {
        }

        public MyCoreAdminDBContext(DbContextOptions<MyCoreAdminDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attribute> Attribute { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttribute { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-VNEERI2;Database=MyCoreAdminDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.ToTable("ATTRIBUTE");

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Attribute)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_ATTRIBUTE_TYPE");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.EstablishedDate).HasMaxLength(10);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_TYPE1");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.AttributeId })
                    .HasName("PK__PRODUCT___081454530E839143");

                entity.ToTable("PRODUCT_ATTRIBUTE");

                entity.Property(e => e.AttributeValue)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ProductAttribute)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_ATTRIBUTE_ATTRIBUTE1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAttribute)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_ATTRIBUTE_PRODUCT");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("TYPE");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(300);
            });
        }
    }
}
