using FornecedorApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Infra.Data.Mappings
{
    public class FornecedorMap: IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("FORNECEDOR");

            builder.HasKey(f => f.IdFornecedor);

            builder.Property(f => f.IdFornecedor)
                .HasColumnName("IDFORNECEDOR");

            builder.Property(f => f.Nome)
                 .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Cnpj)
                .HasColumnName("CNPJ")
               .IsRequired();

            builder.Property(c => c.Telefone)
            .HasColumnName("TELEFONE")
            .HasColumnType("varchar(20)")
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(f => f.IdEndereco)
               .HasColumnName("IDENDERECO")
               .IsRequired();

            builder.HasOne(f => f.Endereco) 
                .WithMany() 
                .HasForeignKey(p => p.IdEndereco); 

        }
    }
}
