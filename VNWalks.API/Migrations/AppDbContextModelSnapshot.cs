﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VNWalks.API.Data;

#nullable disable

namespace VNWalks.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VNWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("752498e4-2f26-43a0-a7ab-bb80786b656b"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("4267ac23-8ac0-4d8a-9a8c-50abd5e1b57b"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("ff05d366-448d-4a90-8a63-4974055a1daf"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("VNWalks.API.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("VNWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d5ee681a-5fd0-4d27-997b-635c62d615d8"),
                            Code = "HN",
                            Name = "Hà Nội",
                            RegionImageUrl = "https://example.com/images/ha-noi.jpg"
                        },
                        new
                        {
                            Id = new Guid("b7211821-39ce-4f38-8c7c-26cee55c3f98"),
                            Code = "HCM",
                            Name = "Hồ Chí Minh",
                            RegionImageUrl = "https://example.com/images/ho-chi-minh.jpg"
                        },
                        new
                        {
                            Id = new Guid("b4036a50-eb15-4ffd-832c-f32f1aa5a1d5"),
                            Code = "DN",
                            Name = "Đà Nẵng",
                            RegionImageUrl = "https://example.com/images/da-nang.jpg"
                        },
                        new
                        {
                            Id = new Guid("c5cf1405-b511-4f93-8693-7bc7dd4ff5ee"),
                            Code = "HP",
                            Name = "Hải Phòng",
                            RegionImageUrl = "https://example.com/images/hai-phong.jpg"
                        },
                        new
                        {
                            Id = new Guid("afce7fa8-e4fa-4780-84bd-f5dbfcd28c45"),
                            Code = "QN",
                            Name = "Quảng Ninh",
                            RegionImageUrl = "https://example.com/images/quang-ninh.jpg"
                        },
                        new
                        {
                            Id = new Guid("95e8a2c6-c877-4d0b-9ecb-5d8a32106e24"),
                            Code = "DL",
                            Name = "Đà Lạt",
                            RegionImageUrl = "https://example.com/images/da-lat.jpg"
                        },
                        new
                        {
                            Id = new Guid("3018c7a0-5dbb-49be-a722-f076d6987492"),
                            Code = "VT",
                            Name = "Vũng Tàu",
                            RegionImageUrl = "https://example.com/images/vung-tau.jpg"
                        });
                });

            modelBuilder.Entity("VNWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("VNWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("VNWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VNWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
