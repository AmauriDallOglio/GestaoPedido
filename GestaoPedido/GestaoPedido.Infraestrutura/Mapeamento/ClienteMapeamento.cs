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

CREATE TABLE Cliente (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,

    Nome NVARCHAR(150) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    Ativo BIT NOT NULL DEFAULT 0 -- Define um valor padrão
);

        INSERT INTO Cliente (Id, Nome, Email) 
        VALUES (NEWID(), 'Cliente1', 'cliente1@teste.com.br');

          select * from Cliente


         */
    }
}
