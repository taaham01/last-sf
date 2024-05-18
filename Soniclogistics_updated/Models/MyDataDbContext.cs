using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Soniclogistics_updated.Models;

public partial class MyDataDbContext : DbContext
{
    public MyDataDbContext()
    {
    }

    public MyDataDbContext(DbContextOptions<MyDataDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Grn> Grns { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Po> Pos { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rfq> Rfqs { get; set; }

    public virtual DbSet<SaleInvoice> SaleInvoices { get; set; }

    public virtual DbSet<SaleOrder> SaleOrders { get; set; }

    public virtual DbSet<SalesQuote> SalesQuotes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8CNU755;Initial Catalog=db_data;Integrated Security=true;Database=SonicLogistics1;Persist Security Info=True;Encrypt=true;TrustServerCertificate=yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId).ValueGeneratedNever();
            entity.Property(e => e.Email).IsFixedLength();
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Grn>(entity =>
        {
            entity.Property(e => e.GrnId).ValueGeneratedNever();

            entity.HasOne(d => d.Order).WithMany(p => p.Grns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRN_PO");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.Property(e => e.InvoiceId).ValueGeneratedNever();

            entity.HasOne(d => d.Grn).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_PO_GRN");
        });

        modelBuilder.Entity<Po>(entity =>
        {
            entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.HasOne(d => d.Prod).WithMany(p => p.Pos).HasConstraintName("FK_PO_Products");

            entity.HasOne(d => d.Sup).WithMany(p => p.Pos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PO_Supplier");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProdId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SaleInvoice>(entity =>
        {
            entity.Property(e => e.SaleInvoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SaleOrder>(entity =>
        {
            entity.Property(e => e.SaleOrderId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SalesQuote>(entity =>
        {
            entity.Property(e => e.Sqid).ValueGeneratedNever();
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.SupId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
