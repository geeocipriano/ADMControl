﻿// <auto-generated />
using ADMControl.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ADMControl.Dominio.Migrations
{
    [DbContext(typeof(EfDbContext))]
    [Migration("20230616141016_TabelaColaborador")]
    partial class TabelaColaborador
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ADMControl.Dominio.Entidades.Categoria", b =>
                {
                    b.Property<int>("CAT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CAT_NOME")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CAT_ID");

                    b.ToTable("CATEGORIA", (string)null);
                });

            modelBuilder.Entity("ADMControl.Dominio.Entidades.Colaborador", b =>
                {
                    b.Property<int>("COL_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("COL_ATIVO")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("COL_NOME")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("COL_ID");

                    b.ToTable("COLABORADOR", (string)null);
                });

            modelBuilder.Entity("ADMControl.Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("PRO_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("PRO_ATU")
                        .HasColumnType("double");

                    b.Property<string>("PRO_DESC")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PRO_IDCATEGORIA")
                        .HasColumnType("int");

                    b.Property<int>("PRO_IDUNIDADE")
                        .HasColumnType("int");

                    b.Property<double>("PRO_MAX")
                        .HasColumnType("double");

                    b.Property<double>("PRO_MIN")
                        .HasColumnType("double");

                    b.HasKey("PRO_ID");

                    b.HasIndex("PRO_IDCATEGORIA");

                    b.HasIndex("PRO_IDUNIDADE");

                    b.ToTable("PRODUTO", (string)null);
                });

            modelBuilder.Entity("ADMControl.Dominio.Entidades.Unidade", b =>
                {
                    b.Property<int>("UNI_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UNI_NOME")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UNI_SIGLA")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UNI_ID");

                    b.ToTable("UNIDADE", (string)null);
                });

            modelBuilder.Entity("ADMControl.Dominio.Entidades.Produto", b =>
                {
                    b.HasOne("ADMControl.Dominio.Entidades.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("PRO_IDCATEGORIA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ADMControl.Dominio.Entidades.Unidade", "Unidade")
                        .WithMany()
                        .HasForeignKey("PRO_IDUNIDADE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Unidade");
                });
#pragma warning restore 612, 618
        }
    }
}
