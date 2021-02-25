﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Domain.Entity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.Entity.Closure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp(0)");

                    b.Property<decimal>("Total")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Closures");
                });

            modelBuilder.Entity("Domain.Entity.ClosurePaymentType", b =>
                {
                    b.Property<int>("ClosureId");

                    b.Property<int>("PaymentTypeId");

                    b.Property<decimal>("Total")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ClosureId", "PaymentTypeId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("ClosurePaymentTypes");
                });

            modelBuilder.Entity("Domain.Entity.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("CreatorId");

                    b.Property<string>("Name");

                    b.Property<int?>("ProducerId");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("UpdaterId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProducerId");

                    b.HasIndex("UpdaterId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Domain.Entity.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("PayedTax")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PaymentTypeId");

                    b.Property<int>("SaleId");

                    b.Property<decimal>("Tax")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Value")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("SaleId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Domain.Entity.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Tax")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("Domain.Entity.PointOfSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("CreatorId");

                    b.Property<int>("EventId");

                    b.Property<string>("Name");

                    b.Property<int?>("TerminalId");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("UpdaterId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("EventId");

                    b.HasIndex("TerminalId");

                    b.HasIndex("UpdaterId");

                    b.ToTable("PointOfSales");
                });

            modelBuilder.Entity("Domain.Entity.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Producer");
                });

            modelBuilder.Entity("Domain.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("CreatorId");

                    b.Property<int>("EventId");

                    b.Property<string>("Name");

                    b.Property<decimal?>("PurchasePrice")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("SalePrice")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("UpdaterId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("EventId");

                    b.HasIndex("UpdaterId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Entity.ProductComposition", b =>
                {
                    b.Property<int>("MasterProductId");

                    b.Property<int>("SlaveProductId");

                    b.Property<int>("Amount");

                    b.Property<decimal>("ProratedValue")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("MasterProductId", "SlaveProductId");

                    b.HasIndex("SlaveProductId");

                    b.ToTable("ProductCompositions");
                });

            modelBuilder.Entity("Domain.Entity.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CancellationDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("CancellationUserId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("CreatorId");

                    b.Property<int>("EventId");

                    b.Property<DateTime?>("ProcessingDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("ProcessingUserId");

                    b.Property<int>("State");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("UpdaterId");

                    b.Property<int>("WarehouseId");

                    b.HasKey("Id");

                    b.HasIndex("CancellationUserId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("EventId");

                    b.HasIndex("ProcessingUserId");

                    b.HasIndex("UpdaterId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("Domain.Entity.ReceiptItem", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("ReceiptId");

                    b.Property<int>("Amount");

                    b.HasKey("ProductId", "ReceiptId");

                    b.HasIndex("ReceiptId");

                    b.ToTable("ReceiptItems");
                });

            modelBuilder.Entity("Domain.Entity.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CancellationDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("CancellationUserId");

                    b.Property<int?>("ClosureId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("CreatorId");

                    b.Property<int>("EventId");

                    b.Property<DateTime?>("ProcessingDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("ProcessingUserId");

                    b.Property<decimal?>("Profit")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("State");

                    b.Property<decimal>("Total")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("TotalPayedTax")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("UpdaterId");

                    b.HasKey("Id");

                    b.HasIndex("CancellationUserId");

                    b.HasIndex("ClosureId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("EventId");

                    b.HasIndex("ProcessingUserId");

                    b.HasIndex("UpdaterId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Domain.Entity.SaleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("ProductId");

                    b.Property<int>("SaleId");

                    b.Property<decimal>("Total")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("UnitPrice")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleItems");
                });

            modelBuilder.Entity("Domain.Entity.SaleItemComposition", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("SaleItemId");

                    b.Property<int>("Amount");

                    b.Property<decimal>("Total")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("UnitPrice")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ProductId", "SaleItemId");

                    b.HasIndex("SaleItemId");

                    b.ToTable("SaleItemCompositions");
                });

            modelBuilder.Entity("Domain.Entity.Terminal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("Identifier");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp(0)");

                    b.HasKey("Id");

                    b.ToTable("Terminal");
                });

            modelBuilder.Entity("Domain.Entity.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CancellationDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("CancellationUserId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("CreatorId");

                    b.Property<int>("EventId");

                    b.Property<DateTime?>("ProcessingDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("ProcessingUserId");

                    b.Property<int>("State");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp(0)");

                    b.Property<string>("UpdaterId");

                    b.Property<int>("WarehouseDestinyId");

                    b.Property<int>("WarehouseOriginId");

                    b.HasKey("Id");

                    b.HasIndex("CancellationUserId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("EventId");

                    b.HasIndex("ProcessingUserId");

                    b.HasIndex("UpdaterId");

                    b.HasIndex("WarehouseDestinyId");

                    b.HasIndex("WarehouseOriginId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("Domain.Entity.TransferItem", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("TransferId");

                    b.Property<int>("Amount");

                    b.HasKey("ProductId", "TransferId");

                    b.HasIndex("TransferId");

                    b.ToTable("TransferItems");
                });

            modelBuilder.Entity("Domain.Entity.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("Domain.Entity.WarehouseProduct", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("WarehouseId");

                    b.Property<int>("Amount");

                    b.HasKey("ProductId", "WarehouseId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WarehouseProducts");
                });

            modelBuilder.Entity("Domain.Entity.WarehouseTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("ProductId");

                    b.Property<int>("Type");

                    b.Property<int>("WarehouseId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WarehouseTransactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Entity.ClosurePaymentType", b =>
                {
                    b.HasOne("Domain.Entity.Closure", "Closure")
                        .WithMany("ClosurePaymentTypes")
                        .HasForeignKey("ClosureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.Event", b =>
                {
                    b.HasOne("Domain.Entity.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Domain.Entity.Producer", "Producer")
                        .WithMany("Events")
                        .HasForeignKey("ProducerId");

                    b.HasOne("Domain.Entity.ApplicationUser", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdaterId");
                });

            modelBuilder.Entity("Domain.Entity.Payment", b =>
                {
                    b.HasOne("Domain.Entity.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Sale")
                        .WithMany("Payments")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.PaymentType", b =>
                {
                    b.HasOne("Domain.Entity.Event", "Event")
                        .WithMany("PaymentTypes")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.PointOfSale", b =>
                {
                    b.HasOne("Domain.Entity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Entity.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Domain.Entity.Event", "Event")
                        .WithMany("PointsOfSale")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Terminal", "Terminal")
                        .WithMany()
                        .HasForeignKey("TerminalId");

                    b.HasOne("Domain.Entity.ApplicationUser", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdaterId");
                });

            modelBuilder.Entity("Domain.Entity.Product", b =>
                {
                    b.HasOne("Domain.Entity.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Domain.Entity.Event", "Event")
                        .WithMany("Products")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.ApplicationUser", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdaterId");
                });

            modelBuilder.Entity("Domain.Entity.ProductComposition", b =>
                {
                    b.HasOne("Domain.Entity.Product", "MasterProduct")
                        .WithMany("Composition")
                        .HasForeignKey("MasterProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Product", "SlaveProduct")
                        .WithMany("Compositor")
                        .HasForeignKey("SlaveProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.Receipt", b =>
                {
                    b.HasOne("Domain.Entity.ApplicationUser", "CancellationUser")
                        .WithMany()
                        .HasForeignKey("CancellationUserId");

                    b.HasOne("Domain.Entity.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Domain.Entity.Event", "Event")
                        .WithMany("Receipts")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.ApplicationUser", "ProcessingUser")
                        .WithMany()
                        .HasForeignKey("ProcessingUserId");

                    b.HasOne("Domain.Entity.ApplicationUser", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdaterId");

                    b.HasOne("Domain.Entity.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.ReceiptItem", b =>
                {
                    b.HasOne("Domain.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Receipt", "Receipt")
                        .WithMany("Items")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.Sale", b =>
                {
                    b.HasOne("Domain.Entity.ApplicationUser", "CancellationUser")
                        .WithMany()
                        .HasForeignKey("CancellationUserId");

                    b.HasOne("Domain.Entity.Closure", "Closure")
                        .WithMany("Sales")
                        .HasForeignKey("ClosureId");

                    b.HasOne("Domain.Entity.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Domain.Entity.Event", "Event")
                        .WithMany("Sales")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.ApplicationUser", "ProcessingUser")
                        .WithMany()
                        .HasForeignKey("ProcessingUserId");

                    b.HasOne("Domain.Entity.ApplicationUser", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdaterId");
                });

            modelBuilder.Entity("Domain.Entity.SaleItem", b =>
                {
                    b.HasOne("Domain.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Sale", "Sale")
                        .WithMany("Items")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.SaleItemComposition", b =>
                {
                    b.HasOne("Domain.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.SaleItem", "SaleItem")
                        .WithMany()
                        .HasForeignKey("SaleItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.Transfer", b =>
                {
                    b.HasOne("Domain.Entity.ApplicationUser", "CancellationUser")
                        .WithMany()
                        .HasForeignKey("CancellationUserId");

                    b.HasOne("Domain.Entity.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Domain.Entity.Event", "Event")
                        .WithMany("Transfers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.ApplicationUser", "ProcessingUser")
                        .WithMany()
                        .HasForeignKey("ProcessingUserId");

                    b.HasOne("Domain.Entity.ApplicationUser", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdaterId");

                    b.HasOne("Domain.Entity.Warehouse", "WarehouseDestiny")
                        .WithMany()
                        .HasForeignKey("WarehouseDestinyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Warehouse", "WarehouseOrigin")
                        .WithMany()
                        .HasForeignKey("WarehouseOriginId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.TransferItem", b =>
                {
                    b.HasOne("Domain.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Transfer", "Transfer")
                        .WithMany("Items")
                        .HasForeignKey("TransferId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.Warehouse", b =>
                {
                    b.HasOne("Domain.Entity.Event", "Event")
                        .WithMany("Warehouses")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.WarehouseProduct", b =>
                {
                    b.HasOne("Domain.Entity.Product", "Product")
                        .WithMany("WarehouseAvailability")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Warehouse", "Warehouse")
                        .WithMany("Stock")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.WarehouseTransaction", b =>
                {
                    b.HasOne("Domain.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
