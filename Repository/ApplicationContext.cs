using System;
using System.IO;
using System.Linq;
using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Configuration;

namespace Repository
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<PointOfSale> PointOfSales { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComposition> ProductCompositions { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
        public DbSet<WarehouseTransaction> WarehouseTransactions { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptItem> ReceiptItems { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<TransferItem> TransferItems { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<SaleItemComposition> SaleItemCompositions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Closure> Closures { get; set; }
        public DbSet<ClosurePaymentType> ClosurePaymentTypes { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ProductCompositionConfiguration).Assembly);
            
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal)))
            {
                property.Relational().ColumnType = "decimal(18, 2)";
            }
            
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(double)))
            {
                property.Relational().ColumnType = "decimal(18, 2)";
            }
            
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal?)))
            {
                property.Relational().ColumnType = "decimal(18, 2)";
            }
            
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(double?)))
            {
                property.Relational().ColumnType = "decimal(18, 2)";
            }
            
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(DateTime)))
            {
                property.Relational().ColumnType = "timestamp(0)";
            }
            
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(DateTime?)))
            {
                property.Relational().ColumnType = "timestamp(0)";
            }
        }
    }
}