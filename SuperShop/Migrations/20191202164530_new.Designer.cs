﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperShop.Data;

namespace SuperShop.Migrations
{
    [DbContext(typeof(AppDbContent))]
    [Migration("20191202164530_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuperShop.Data.Models.Car", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<bool>("IsFavorite");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.Property<bool>("available");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<long>("priece");

                    b.HasKey("id");

                    b.HasIndex("CategoryId");

                    b.ToTable("car");
                });

            modelBuilder.Entity("SuperShop.Data.Models.CarDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId");

                    b.Property<string>("img");

                    b.Property<string>("img1");

                    b.Property<string>("img2");

                    b.Property<string>("year");

                    b.HasKey("id");

                    b.ToTable("CarDetails");
                });

            modelBuilder.Entity("SuperShop.Data.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<string>("description");

                    b.HasKey("id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("SuperShop.Data.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderTime");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("phone")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("order");
                });

            modelBuilder.Entity("SuperShop.Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId");

                    b.Property<int>("OrderId");

                    b.Property<long>("price");

                    b.HasKey("id");

                    b.HasIndex("CarId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("SuperShop.Data.Models.ShopCardItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShopCardId");

                    b.Property<int?>("carid");

                    b.Property<int>("priece");

                    b.HasKey("id");

                    b.HasIndex("carid");

                    b.ToTable("ShopCardItem");
                });

            modelBuilder.Entity("SuperShop.Data.Models.Car", b =>
                {
                    b.HasOne("SuperShop.Data.Models.Category", "Category")
                        .WithMany("cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SuperShop.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("SuperShop.Data.Models.Car", "car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SuperShop.Data.Models.Order", "order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SuperShop.Data.Models.ShopCardItem", b =>
                {
                    b.HasOne("SuperShop.Data.Models.Car", "car")
                        .WithMany()
                        .HasForeignKey("carid");
                });
#pragma warning restore 612, 618
        }
    }
}
