﻿// <auto-generated />
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220126162523_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AtorFilme", b =>
                {
                    b.Property<int>("AtoresAtorId")
                        .HasColumnType("int");

                    b.Property<int>("FilmesId")
                        .HasColumnType("int");

                    b.HasKey("AtoresAtorId", "FilmesId");

                    b.HasIndex("FilmesId");

                    b.ToTable("AtorFilme");
                });

            modelBuilder.Entity("Domain.Models.Ator", b =>
                {
                    b.Property<int>("AtorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AtorId"), 1L, 1);

                    b.Property<string>("NomeAtor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AtorId");

                    b.ToTable("Atores");
                });

            modelBuilder.Entity("Domain.Models.Diretor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NomeDiretor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diretores");
                });

            modelBuilder.Entity("Domain.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DiretorId")
                        .HasColumnType("int");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiretorId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Domain.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TipoGenero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Domain.Models.Votos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ValorDoVoto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Votos");
                });

            modelBuilder.Entity("FilmeGenero", b =>
                {
                    b.Property<int>("FilmesId")
                        .HasColumnType("int");

                    b.Property<int>("GenerosId")
                        .HasColumnType("int");

                    b.HasKey("FilmesId", "GenerosId");

                    b.HasIndex("GenerosId");

                    b.ToTable("FilmeGenero");
                });

            modelBuilder.Entity("FilmeVotos", b =>
                {
                    b.Property<int>("FilmesId")
                        .HasColumnType("int");

                    b.Property<int>("VotosId")
                        .HasColumnType("int");

                    b.HasKey("FilmesId", "VotosId");

                    b.HasIndex("VotosId");

                    b.ToTable("FilmeVotos");
                });

            modelBuilder.Entity("AtorFilme", b =>
                {
                    b.HasOne("Domain.Models.Ator", null)
                        .WithMany()
                        .HasForeignKey("AtoresAtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Filme", b =>
                {
                    b.HasOne("Domain.Models.Diretor", "Diretor")
                        .WithMany("Filmes")
                        .HasForeignKey("DiretorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");
                });

            modelBuilder.Entity("FilmeGenero", b =>
                {
                    b.HasOne("Domain.Models.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmeVotos", b =>
                {
                    b.HasOne("Domain.Models.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Votos", null)
                        .WithMany()
                        .HasForeignKey("VotosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Diretor", b =>
                {
                    b.Navigation("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}
