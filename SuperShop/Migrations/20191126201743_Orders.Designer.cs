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
    [Migration("20191126201743_Orders")]
    partial class Orders
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

                    b.Property<string>("LongDescription");

                    b.Property<string>("ShortDescription");

                    b.Property<bool>("available");

                    b.Property<string>("img");

                    b.Property<string>("name");

                    b.Property<long>("priece");

                    b.HasKey("id");

                    b.HasIndex("CategoryId");

                    b.ToTable("car");
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

                    b.Property<string>("SurName");

                    b.Property<string>("adress");

                    b.Property<string>("email");

                    b.Property<string>("name");

                    b.Property<string>("phone");

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

                    b.Property<long>("priece");

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
