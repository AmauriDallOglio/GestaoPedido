using GestaoPedido.Dominio.Entidade;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPedido.Infraestrutura.Mapeamento
{
    public class PedidoMapeamento : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Id_Cliente).IsRequired();

            builder.Property(p => p.DataPedido)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(p => p.ValorTotal)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();



            builder.HasOne(p => p.Cliente)
             .WithMany()
             .HasForeignKey(p => p.Id_Cliente)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PedidoProdutos)
                .WithOne(pp => pp.Pedido)
                .HasForeignKey(pp => pp.Id_Pedido)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}




/*
       * 
       * 
CREATE TABLE Pedido (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Id_Cliente UNIQUEIDENTIFIER NOT NULL,
    DataPedido DATETIME NOT NULL DEFAULT GETUTCDATE(),
    ValorTotal DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (Id_Cliente) REFERENCES Cliente(Id)
);



       * 
       */