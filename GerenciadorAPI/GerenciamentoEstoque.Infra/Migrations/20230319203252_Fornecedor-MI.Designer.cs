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
    [Migration("20230319203252_Fornecedor-MI")]
    partial class FornecedorMI
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProdutoVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Fornecedor", (string)null);
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

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("GerenciamentoEstoque.Domain.Entities.Fornecedor", b =>
                {
                    b.OwnsOne("GerenciamentoEstoque.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("EnderecoEmail")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });

                    b.Navigation("Email")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
