﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240117215146_Creacioninicial")]
    partial class Creacioninicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Dominio.JugadorFemenino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NivelHabilidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TiempoDeReaccion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JugadoresFemeninos");
                });

            modelBuilder.Entity("Data.Dominio.JugadorMasculino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Fuerza")
                        .HasColumnType("int");

                    b.Property<int>("NivelHabilidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Velocidad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JugadoresMasculinos");
                });

            modelBuilder.Entity("Data.Dominio.PartidoFemenino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdGanador")
                        .HasColumnType("int");

                    b.Property<int>("IdJugador1")
                        .HasColumnType("int");

                    b.Property<int>("IdJugador2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGanador");

                    b.HasIndex("IdJugador1");

                    b.HasIndex("IdJugador2");

                    b.ToTable("PartidosFemeninos");
                });

            modelBuilder.Entity("Data.Dominio.PartidoMasculino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdGanador")
                        .HasColumnType("int");

                    b.Property<int>("IdJugador1")
                        .HasColumnType("int");

                    b.Property<int>("IdJugador2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGanador");

                    b.HasIndex("IdJugador1");

                    b.HasIndex("IdJugador2");

                    b.ToTable("PartidosMasculinos");
                });

            modelBuilder.Entity("Data.Dominio.PartidoFemenino", b =>
                {
                    b.HasOne("Data.Dominio.JugadorFemenino", "Ganador")
                        .WithMany()
                        .HasForeignKey("IdGanador");

                    b.HasOne("Data.Dominio.JugadorFemenino", "Jugador1")
                        .WithMany()
                        .HasForeignKey("IdJugador1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Dominio.JugadorFemenino", "Jugador2")
                        .WithMany()
                        .HasForeignKey("IdJugador2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ganador");

                    b.Navigation("Jugador1");

                    b.Navigation("Jugador2");
                });

            modelBuilder.Entity("Data.Dominio.PartidoMasculino", b =>
                {
                    b.HasOne("Data.Dominio.JugadorMasculino", "Ganador")
                        .WithMany()
                        .HasForeignKey("IdGanador");

                    b.HasOne("Data.Dominio.JugadorMasculino", "Jugador1")
                        .WithMany()
                        .HasForeignKey("IdJugador1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Dominio.JugadorMasculino", "Jugador2")
                        .WithMany()
                        .HasForeignKey("IdJugador2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ganador");

                    b.Navigation("Jugador1");

                    b.Navigation("Jugador2");
                });
#pragma warning restore 612, 618
        }
    }
}
