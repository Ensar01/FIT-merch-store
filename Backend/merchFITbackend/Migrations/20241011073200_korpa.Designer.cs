﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using merchFITbackend.Data;

#nullable disable

namespace merchFITbackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241011073200_korpa")]
    partial class korpa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("merchFITbackend.Data.Models.Dostavljac", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrojTelefona")
                        .HasColumnType("int");

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Dostavljac");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Kategorija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRegistracije")
                        .HasColumnType("datetime2");

                    b.Property<string>("Drzava")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Korpa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<int>("DostavljacID")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DostavljacID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("Korpa");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Narudzba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DatumNarudzbe")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Podkategorija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KategorijaID");

                    b.ToTable("Podkategorija");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Proizvod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PodkategorijaID")
                        .HasColumnType("int");

                    b.Property<string>("SlikaProizvoda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UzrastID")
                        .HasColumnType("int");

                    b.Property<int>("Zaliha")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PodkategorijaID");

                    b.HasIndex("UzrastID");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.ProizvodVelicina", b =>
                {
                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.Property<int>("VelicinaID")
                        .HasColumnType("int");

                    b.HasKey("ProizvodID", "VelicinaID");

                    b.HasIndex("VelicinaID");

                    b.ToTable("ProizvodVelicina");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.StavkeNarudzbe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaID")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NarudzbaID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("StavkeNarudzbe");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Uzrast", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Uzrast");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Velicina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Velicina");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Korpa", b =>
                {
                    b.HasOne("merchFITbackend.Data.Models.Dostavljac", "Dostavljac")
                        .WithMany()
                        .HasForeignKey("DostavljacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("merchFITbackend.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dostavljac");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Narudzba", b =>
                {
                    b.HasOne("merchFITbackend.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Podkategorija", b =>
                {
                    b.HasOne("merchFITbackend.Data.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorija");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Proizvod", b =>
                {
                    b.HasOne("merchFITbackend.Data.Models.Podkategorija", "Podkategorija")
                        .WithMany()
                        .HasForeignKey("PodkategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("merchFITbackend.Data.Models.Uzrast", "Uzrast")
                        .WithMany()
                        .HasForeignKey("UzrastID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Podkategorija");

                    b.Navigation("Uzrast");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.ProizvodVelicina", b =>
                {
                    b.HasOne("merchFITbackend.Data.Models.Proizvod", "Proizvod")
                        .WithMany("Velicine")
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("merchFITbackend.Data.Models.Velicina", "Velicina")
                        .WithMany("Proizvod")
                        .HasForeignKey("VelicinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proizvod");

                    b.Navigation("Velicina");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.StavkeNarudzbe", b =>
                {
                    b.HasOne("merchFITbackend.Data.Models.Narudzba", "Narudzba")
                        .WithMany("StavkeNarudzbe")
                        .HasForeignKey("NarudzbaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("merchFITbackend.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Narudzba");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Narudzba", b =>
                {
                    b.Navigation("StavkeNarudzbe");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Proizvod", b =>
                {
                    b.Navigation("Velicine");
                });

            modelBuilder.Entity("merchFITbackend.Data.Models.Velicina", b =>
                {
                    b.Navigation("Proizvod");
                });
#pragma warning restore 612, 618
        }
    }
}
