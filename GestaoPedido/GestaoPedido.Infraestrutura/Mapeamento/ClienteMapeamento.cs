using GestaoPedido.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPedido.Infraestrutura.Mapeamento
{
    public class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedNever().IsRequired(true);
            builder.Property(u => u.Nome).HasColumnType("varchar").HasMaxLength(150).IsRequired(true);
            builder.Property(u => u.Email).HasColumnType("varchar").HasMaxLength(150).IsRequired(true);
            builder.Property(t => t.Inativo).HasColumnName("Inativo").IsRequired(true);
        }

        /*
         * 
         *use GestaoDePedido

PRINT 'Criando tabela Cliente'
GO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Cliente' AND type = 'U')
	BEGIN
		CREATE TABLE Cliente
		(
			Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
			Nome NVARCHAR(150) NOT NULL,
			Email NVARCHAR(150) NOT NULL,
			Inativo BIT NOT NULL DEFAULT 0,

			CONSTRAINT PK_Cliente PRIMARY KEY (Id),
			CONSTRAINT UQ_Cliente_Email UNIQUE (Email)
		);
	END
ELSE
	BEGIN
		PRINT '--> Tabela CLIENTE já existe.'
	END
GO


         */
    }
}
