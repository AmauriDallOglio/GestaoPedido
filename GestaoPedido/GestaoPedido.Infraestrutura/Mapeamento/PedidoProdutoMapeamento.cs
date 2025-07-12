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
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(p => p.Quantidade).IsRequired();
            builder.Property(p => p.PrecoUnitario).HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(p => p.Total).HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(p => p.DataCadastro).HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(p => p.DataAlteracao).IsRequired(false);

            // Relacionamento com Pedido
            builder.HasOne(p => p.Pedido)
                .WithMany(p => p.PedidoProdutos)
                .HasForeignKey(p => p.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento com Produto
            builder.HasOne(p => p.Produto)
                .WithMany()
                .HasForeignKey(p => p.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.ToTable("PedidoProduto");

            //builder.HasKey(pp => pp.Id);
            //builder.Property(pp => pp.Id).HasColumnName("Id");
            //builder.Property(pp => pp.Quantidade).IsRequired();
            //builder.Property(pp => pp.PrecoUnitario).IsRequired().HasColumnType("DECIMAL(18,2)");

            //builder.Ignore(pp => pp.Total);




            //builder.HasOne(pp => pp.Pedido)
            //    .WithMany(p => p.PedidoProdutos)
            //    .HasForeignKey(pp => pp.IdPedido)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(pp => pp.Produto)
            //    .WithMany()
            //    .HasForeignKey(pp => pp.IdProduto)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


/*
       * 
PRINT 'Criando tabela PedidoProduto'
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'PedidoProduto' AND type = 'U')
BEGIN
    CREATE TABLE PedidoProduto
    (
        Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
        IdPedido UNIQUEIDENTIFIER NOT NULL,
        IdProduto UNIQUEIDENTIFIER NOT NULL,
        Quantidade INT NOT NULL CHECK (Quantidade > 0),
        PrecoUnitario DECIMAL(12,2) NOT NULL CHECK (PrecoUnitario >= 0),
        Total DECIMAL(12,2) NOT NULL CHECK (Total >= 0),
	    DataCadastro DATETIME NOT NULL DEFAULT GETDATE(),
        DataAlteracao DATETIME NULL,

        CONSTRAINT PK_PedidoProduto PRIMARY KEY (Id),
        CONSTRAINT FK_PedidoProduto_Pedido FOREIGN KEY (IdPedido) REFERENCES Pedido(Id) ON DELETE CASCADE,
        CONSTRAINT FK_PedidoProduto_Produto FOREIGN KEY (IdProduto) REFERENCES Produto(Id)
    );
END
ELSE
BEGIN
    PRINT '--> Tabela PEDIDOPRODUTO já existe.'
END
GO


       * 
       */