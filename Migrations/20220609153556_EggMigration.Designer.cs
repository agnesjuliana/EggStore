﻿// <auto-generated />
using System;
using EggStore.Infrastucture.Shareds.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EggStore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220609153556_EggMigration")]
    partial class EggMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EggStore.Domains.Eggs.Entities.EggsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("EggName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("egg_name");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<int>("Stok")
                        .HasColumnType("int")
                        .HasColumnName("stok");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("package_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("package_id");

                    b.ToTable("eggs");
                });

            modelBuilder.Entity("EggStore.Domains.Packages.Entities.PackagesEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("package_name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("packages");
                });

            modelBuilder.Entity("EggStore.Domains.Eggs.Entities.EggsEntity", b =>
                {
                    b.HasOne("EggStore.Domains.Packages.Entities.PackagesEntity", "PackageEntity")
                        .WithMany()
                        .HasForeignKey("package_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PackageEntity");
                });
#pragma warning restore 612, 618
        }
    }
}