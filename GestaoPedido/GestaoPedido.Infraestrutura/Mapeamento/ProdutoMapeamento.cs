using GestaoPedido.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPedido.Infraestrutura.Mapeamento
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(50);
            builder.HasIndex(p => p.Codigo).IsUnique();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Descricao).HasMaxLength(500);
            builder.Property(p => p.Preco).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Quantidade).IsRequired();
            builder.Property(p => p.Inativo).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.DataCadastro).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.DataAlteracao).IsRequired(false);
        }


        /*
         * 
         * 
 

PRINT 'Criando tabela Produto'
GO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Produto' AND type = 'U')
BEGIN
    CREATE TABLE Produto
    (
        Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
        Codigo NVARCHAR(50) NOT NULL,
        Nome NVARCHAR(200) NOT NULL,
        Descricao NVARCHAR(500) NULL,
        Preco DECIMAL(18,2) NOT NULL,
        Quantidade INT NOT NULL,
        Inativo BIT NOT NULL DEFAULT 0,
        DataCadastro DATETIME NOT NULL DEFAULT GETDATE(),
        DataAlteracao DATETIME NOT NULL DEFAULT GETDATE(),

        CONSTRAINT PK_Produto PRIMARY KEY (Id),
        CONSTRAINT UQ_Produto_Codigo UNIQUE (Codigo)
    );
END
ELSE
BEGIN
    PRINT '--> Tabela PRODUTO já existe.'
END
GO

         */
    }
}
