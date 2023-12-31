﻿// <auto-generated />
using System;
using FornecedorApi.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FornecedorApi.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FornecedorApi.Domain.Entities.Endereco", b =>
                {
                    b.Property<Guid?>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDENDERECO");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BAIRRO");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CIDADE");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("COMPLEMENTO");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ESTADO");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("LOGRADOURO");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NUMERO");

                    b.HasKey("IdEndereco");

                    b.ToTable("ENDERECO", (string)null);
                });

            modelBuilder.Entity("FornecedorApi.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<Guid?>("IdFornecedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDFORNECEDOR");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CNPJ");

                    b.Property<Guid?>("EnderecoIdEndereco")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdEndereco")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDENDERECO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("IdFornecedor");

                    b.HasIndex("EnderecoIdEndereco");

                    b.HasIndex("IdEndereco");

                    b.ToTable("FORNECEDOR", (string)null);
                });

            modelBuilder.Entity("FornecedorApi.Domain.Entities.Fornecedor", b =>
                {
                    b.HasOne("FornecedorApi.Domain.Entities.Endereco", null)
                        .WithMany("Forenecedores")
                        .HasForeignKey("EnderecoIdEndereco");

                    b.HasOne("FornecedorApi.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("FornecedorApi.Domain.Entities.Endereco", b =>
                {
                    b.Navigation("Forenecedores");
                });
#pragma warning restore 612, 618
        }
    }
}
