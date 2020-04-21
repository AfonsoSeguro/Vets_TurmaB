﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Veterinarios.Data;

namespace Veterinarios.Migrations
{
    [DbContext(typeof(VetsBD))]
    [Migration("20200421141305_sexualzar")]
    partial class sexualzar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Veterinarios.Models.Animais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("donoFK")
                        .HasColumnType("int");

                    b.Property<string>("especie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("peso")
                        .HasColumnType("float");

                    b.Property<string>("raca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("donoFK");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("Veterinarios.Models.Consultas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("animal")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<int>("vet")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("animal");

                    b.HasIndex("vet");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("Veterinarios.Models.Donos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Donos");
                });

            modelBuilder.Entity("Veterinarios.Models.Veter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nCelula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Veterinarios");
                });

            modelBuilder.Entity("Veterinarios.Models.Animais", b =>
                {
                    b.HasOne("Veterinarios.Models.Donos", "dono")
                        .WithMany("listaAnimais")
                        .HasForeignKey("donoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Veterinarios.Models.Consultas", b =>
                {
                    b.HasOne("Veterinarios.Models.Animais", "animalFK")
                        .WithMany("listaConsultas")
                        .HasForeignKey("animal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Veterinarios.Models.Veter", "vetFK")
                        .WithMany("listaConsultas")
                        .HasForeignKey("vet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}