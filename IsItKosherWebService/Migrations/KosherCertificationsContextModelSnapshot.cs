﻿// <auto-generated />
using System;
using IsItKosherWebService.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IsItKosherWebService.Migrations
{
    [DbContext(typeof(KosherCertificationsContext))]
    partial class KosherCertificationsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-preview.7.20365.15");

            modelBuilder.Entity("IsItKosherWebService.Entities.KosherCertification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RabbiFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RabbiLastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KosherCertifications");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Name = "Ok Kosher",
                            PhoneNumber = "6462714233",
                            RabbiFirstName = "Rabbi Tzvi",
                            RabbiLastName = "Tornek"
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Name = "Orthodox Union",
                            PhoneNumber = "2628945438",
                            RabbiFirstName = "Rabbi Tova",
                            RabbiLastName = "Tornek"
                        });
                });

            modelBuilder.Entity("IsItKosherWebService.Entities.KosherSymbol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Image")
                        .HasColumnType("image");

                    b.Property<string>("ImageDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("KosherCertificationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("KosherCertificationId");

                    b.ToTable("KosherSymbols");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Image = new byte[0],
                            ImageDescription = "k inside of a circle",
                            KosherCertificationId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                        },
                        new
                        {
                            Id = new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                            Image = new byte[0],
                            ImageDescription = "U inside of a circle",
                            KosherCertificationId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96")
                        });
                });

            modelBuilder.Entity("IsItKosherWebService.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("KosherCertificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KosherCertificationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                            City = "brooklyn",
                            Country = "USA",
                            KosherCertificationId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Latitude = 200f,
                            Longitude = 100f,
                            State = "Ny",
                            Street = "1417 east 16th street",
                            ZipCode = 11225
                        },
                        new
                        {
                            Id = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            City = "brooklyn",
                            Country = "USA",
                            KosherCertificationId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Latitude = 1000f,
                            Longitude = -200f,
                            State = "Ny",
                            Street = "1166 50th street",
                            ZipCode = 11219
                        });
                });

            modelBuilder.Entity("IsItKosherWebService.Entities.KosherSymbol", b =>
                {
                    b.HasOne("IsItKosherWebService.Entities.KosherCertification", "KosherCertification")
                        .WithMany("KosherSymbols")
                        .HasForeignKey("KosherCertificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IsItKosherWebService.Entities.Location", b =>
                {
                    b.HasOne("IsItKosherWebService.Entities.KosherCertification", "KosherCertification")
                        .WithMany("Locations")
                        .HasForeignKey("KosherCertificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
