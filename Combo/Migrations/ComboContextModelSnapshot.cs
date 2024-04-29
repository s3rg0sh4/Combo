﻿// <auto-generated />
using System;
using Combo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Combo.Migrations
{
    [DbContext(typeof(ComboContext))]
    partial class ComboContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Combo.Database.Models.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BoxCount")
                        .HasColumnType("integer");

                    b.Property<int>("PalleteCount")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Cargo");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Combo.Database.Models.Commentary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CommentatorType")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("WaybillId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WaybillId");

                    b.ToTable("Commentary");
                });

            modelBuilder.Entity("Combo.Database.Models.Destiantion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("View")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Destiantion");
                });

            modelBuilder.Entity("Combo.Database.Models.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Combo.Database.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("ArrivalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Orderer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Combo.Database.Models.Trailer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Brend")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MaxPalletes")
                        .HasColumnType("integer");

                    b.Property<string>("PlateIndex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RefrigeratorType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Trailers");
                });

            modelBuilder.Entity("Combo.Database.Models.Truck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BodyNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ChassisNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EditionYear")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Fuel")
                        .HasColumnType("integer");

                    b.Property<int>("FuelRate")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MotorNamber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlateIndex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegisterOrgan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("Combo.Database.Models.Waybill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActualCargoId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeclaredCargoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DestinationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RouteSheetId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Temperature")
                        .HasColumnType("integer");

                    b.Property<string>("TemperatureRemark")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ActualCargoId");

                    b.HasIndex("DeclaredCargoId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("OrderId");

                    b.ToTable("Waybill");
                });

            modelBuilder.Entity("Combo.Database.Models.ActualCargo", b =>
                {
                    b.HasBaseType("Combo.Database.Models.Cargo");

                    b.ToTable("ActualCargo");
                });

            modelBuilder.Entity("Combo.Database.Models.DeclaredCargo", b =>
                {
                    b.HasBaseType("Combo.Database.Models.Cargo");

                    b.ToTable("DeclaredCargo");
                });

            modelBuilder.Entity("Combo.Database.Models.Commentary", b =>
                {
                    b.HasOne("Combo.Database.Models.Waybill", null)
                        .WithMany("Commentaries")
                        .HasForeignKey("WaybillId");
                });

            modelBuilder.Entity("Combo.Database.Models.Waybill", b =>
                {
                    b.HasOne("Combo.Database.Models.ActualCargo", "ActualCargo")
                        .WithMany()
                        .HasForeignKey("ActualCargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Combo.Database.Models.DeclaredCargo", "DeclaredCargo")
                        .WithMany()
                        .HasForeignKey("DeclaredCargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Combo.Database.Models.Destiantion", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Combo.Database.Models.Order", null)
                        .WithMany("Waybills")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActualCargo");

                    b.Navigation("DeclaredCargo");

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("Combo.Database.Models.ActualCargo", b =>
                {
                    b.HasOne("Combo.Database.Models.Cargo", null)
                        .WithOne()
                        .HasForeignKey("Combo.Database.Models.ActualCargo", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Combo.Database.Models.DeclaredCargo", b =>
                {
                    b.HasOne("Combo.Database.Models.Cargo", null)
                        .WithOne()
                        .HasForeignKey("Combo.Database.Models.DeclaredCargo", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Combo.Database.Models.Order", b =>
                {
                    b.Navigation("Waybills");
                });

            modelBuilder.Entity("Combo.Database.Models.Waybill", b =>
                {
                    b.Navigation("Commentaries");
                });
#pragma warning restore 612, 618
        }
    }
}
