using GestaoPedido.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPedido.Infraestrutura.Mapeamento
{
    public class PedidoMapeamento : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(p => p.IdCliente).IsRequired();
            builder.Property(p => p.NumeroPedido).IsRequired().HasMaxLength(30);
            builder.HasIndex(p => p.NumeroPedido).IsUnique();
            builder.Property(p => p.ValorTotal).IsRequired().HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(p => p.Situacao).IsRequired().HasDefaultValue((byte)0);
            builder.Property(p => p.DataCadastro).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.DataAlteracao).IsRequired(false);

            // Relacionamento
            builder.HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PedidoProdutos)
                .WithOne(pp => pp.Pedido)
                .HasForeignKey(pp => pp.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}




/*
       * 
       * 


PRINT 'Criando tabela Pedido'
GO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Pedido' AND type = 'U')
BEGIN
    CREATE TABLE Pedido
    (
        Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
        IdCliente UNIQUEIDENTIFIER NOT NULL,
        NumeroPedido NVARCHAR(30) NOT NULL,
        ValorTotal DECIMAL(18,2) NOT NULL DEFAULT 0,
        Situacao tinyint NOT NULL DEFAULT 0,
        DataCadastro DATETIME NOT NULL DEFAULT GETDATE(),
        DataAlteracao DATETIME NULL,

        CONSTRAINT PK_Pedido PRIMARY KEY (Id),
        CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(Id),
        CONSTRAINT UQ_Pedido_NumeroPedido UNIQUE (NumeroPedido)
    );
END
ELSE
BEGIN
    PRINT '--> Tabela PEDIDO já existe.'
END
GO


       * 
       */