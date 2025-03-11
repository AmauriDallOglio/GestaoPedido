using GestaoPedido.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPedido.Infraestrutura.Mapeamento
{
    public class PedidoProdutoMapeamento : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            builder.ToTable("PedidoProduto");

            builder.HasKey(pp => pp.Id);
            builder.Property(pp => pp.Id).HasColumnName("Id");
            builder.Property(pp => pp.Quantidade).IsRequired();
            builder.Property(pp => pp.PrecoUnitario).IsRequired().HasColumnType("DECIMAL(18,2)");

            builder.Ignore(pp => pp.Total);




            builder.HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidoProdutos)
                .HasForeignKey(pp => pp.Id_Pedido)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Produto)
                .WithMany()
                .HasForeignKey(pp => pp.Id_Produto)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


/*
       * 
        CREATE TABLE PedidoProduto (
            Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
            Id_Pedido UNIQUEIDENTIFIER NOT NULL,
            Id_Produto UNIQUEIDENTIFIER NOT NULL,
            Quantidade INT NOT NULL CHECK (Quantidade > 0),
            PrecoUnitario DECIMAL(18,2) NOT NULL CHECK (PrecoUnitario >= 0),
            Total AS (Quantidade * PrecoUnitario) PERSISTED,
            CONSTRAINT FK_PedidoProduto_Pedido FOREIGN KEY (Id_Pedido) REFERENCES Pedido(Id) ON DELETE CASCADE,
            CONSTRAINT FK_PedidoProduto_Produto FOREIGN KEY (Id_Produto) REFERENCES Produto(Id)
        );

       * 
       */