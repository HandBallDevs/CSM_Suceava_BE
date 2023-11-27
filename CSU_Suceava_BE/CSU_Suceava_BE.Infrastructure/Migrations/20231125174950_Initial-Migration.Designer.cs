﻿// <auto-generated />
using System;
using CSU_Suceava_BE.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSU_Suceava_BE.Infrastructure.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20231125174950_Initial-Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CSU_Suceava_BE.Domain.Entities.IstoricPremii", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPrimire")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumePremiu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("IstoricPremii");
                });

            modelBuilder.Entity("CSU_Suceava_BE.Domain.Entities.IstoricRoluri", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataFinalizare")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataIncepere")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeRol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("IstoricRoluri");
                });

            modelBuilder.Entity("CSU_Suceava_BE.Domain.Entities.Meci", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Acasa")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Editia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkLive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locatia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeAdversar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScorAdversar")
                        .HasColumnType("int");

                    b.Property<int>("ScorCSUSV")
                        .HasColumnType("int");

                    b.Property<int>("StatusMeci")
                        .HasColumnType("int");

                    b.Property<int>("TipCampionat")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Meci");
                });

            modelBuilder.Entity("CSU_Suceava_BE.Domain.Entities.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNastere")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descriere")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Inaltime")
                        .HasPrecision(3, 2)
                        .HasColumnType("float(3)");

                    b.Property<string>("Nationalitate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TipLot")
                        .HasPrecision(1)
                        .HasColumnType("int");

                    b.Property<string>("URLPoza")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("CSU_Suceava_BE.Domain.Entities.Stire", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Continut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAutopostare")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPostare")
                        .HasColumnType("datetime2");

                    b.Property<string>("HashTaguri")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StatusStire")
                        .HasPrecision(1)
                        .HasColumnType("int");

                    b.Property<string>("Titlu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("UtilizatorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UtilizatorId");

                    b.ToTable("Stire");
                });

            modelBuilder.Entity("CSU_Suceava_BE.Domain.Entities.Utilizator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Parola")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Utilizator");
                });

            modelBuilder.Entity("CSU_Suceava_BE.Domain.Entities.IstoricPremii", b =>
                {
                    b.HasOne("CSU_Suceava_BE.Domain.Entities.Staff", "Staff")
                        .WithMany("IstoricPremii")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("CSU_Suceava_BE.Domain.Entities.IstoricRoluri", b =>
                {
                    b.HasOne("CSU_Suceava_BE.Domain.Entities.Staff", "Staff")
                        .WithMany("IstoricRoluri")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("CSU_Suceava_BE.Domain.Entities.Stire", b =>
                {
                    b.HasOne("CSU_Suceava_BE.Domain.Entities.Utilizator", "Utilizator")
                        .WithMany("Stiri")
                        .HasForeignKey("UtilizatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilizator");
                });

            modelBuilder.Entity("CSU_Suceava_BE.Domain.Entities.Staff", b =>
                {
                    b.Navigation("IstoricPremii");

                    b.Navigation("IstoricRoluri");
                });

            modelBuilder.Entity("CSU_Suceava_BE.Domain.Entities.Utilizator", b =>
                {
                    b.Navigation("Stiri");
                });
#pragma warning restore 612, 618
        }
    }
}