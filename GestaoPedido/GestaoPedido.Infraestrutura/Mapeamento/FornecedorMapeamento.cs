using GestaoPedido.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPedido.Infraestrutura.Mapeamento
{
    public class FornecedorMapeamento : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(f => f.Nome).IsRequired().HasMaxLength(100);
            builder.Property(f => f.Documento).IsRequired().HasMaxLength(20);
           // builder.HasIndex(f => f.Documento).IsUnique().HasDatabaseName("UQ_Fornecedor_Documento");
            builder.Property(f => f.Inativo).IsRequired().HasDefaultValue(false);
        }
    }


    /*
     * 
     * 
     * 
	 
PRINT 'Criando tabela Fornecedor'
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Fornecedor' AND type = 'U')
BEGIN
    CREATE TABLE Fornecedor
    (
        Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
        Nome NVARCHAR(100) NOT NULL,
        Documento NVARCHAR(20) NOT NULL,
		Inativo BIT NOT NULL DEFAULT 0,

        CONSTRAINT PK_Fornecedor PRIMARY KEY (Id),
        CONSTRAINT UQ_Fornecedor_Documento UNIQUE (Documento)
    );
END
ELSE
BEGIN
    PRINT '--> Tabela FORNECEDOR já existe.'
END
GO
     * 
     * */
}
