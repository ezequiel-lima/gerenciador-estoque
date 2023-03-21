﻿// <auto-generated />
using System;
using GerenciamentoEstoque.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciamentoEstoque.Infra.Migrations
{
    [DbContext(typeof(GerenciamentoEstoqueDataContext))]
    [Migration("20230321072203_Six")]
    partial class Six
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Estoque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fornecedor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Estoque", (string)null);
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.ItemVenda", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<long>("Quantidade")
                        .HasPrecision(0)
                        .HasColumnType("BIGINT");

                    b.HasKey("Id");

                    b.ToTable("ItemVenda", (string)null);
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR");

                    b.Property<Guid?>("EstoqueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR");

                    b.Property<decimal>("Preco")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<long>("QuantidadeEmEstoque")
                        .HasPrecision(0)
                        .HasColumnType("BIGINT");

                    b.HasKey("Id");

                    b.HasIndex("EstoqueId");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Venda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EstoqueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EstoqueId");

                    b.ToTable("Venda", (string)null);
                });

            modelBuilder.Entity("ItemVendaVenda", b =>
                {
                    b.Property<Guid>("ItensVendasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VendaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ItensVendasId", "VendaId");

                    b.HasIndex("VendaId");

                    b.ToTable("ItemVendaVenda");
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.ItemVenda", b =>
                {
                    b.HasOne("GerenciamentoEstoque.Domain.Entities.Produto", "Produto")
                        .WithOne()
                        .HasForeignKey("GerenciamentoEstoque.Domain.Entities.ItemVenda", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Produto", b =>
                {
                    b.HasOne("GerenciamentoEstoque.Domain.Entities.Estoque", null)
                        .WithMany("Produtos")
                        .HasForeignKey("EstoqueId");
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Venda", b =>
                {
                    b.HasOne("GerenciamentoEstoque.Domain.Entities.Estoque", null)
                        .WithMany("Vendas")
                        .HasForeignKey("EstoqueId");
                });

            modelBuilder.Entity("ItemVendaVenda", b =>
                {
                    b.HasOne("GerenciamentoEstoque.Domain.Entities.ItemVenda", null)
                        .WithMany()
                        .HasForeignKey("ItensVendasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoEstoque.Domain.Entities.Venda", null)
                        .WithMany()
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Estoque", b =>
                {
                    b.Navigation("Produtos");

                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
