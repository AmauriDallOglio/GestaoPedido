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
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(500);
            builder.Property(p => p.Preco).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.Quantidade).IsRequired();
            builder.Property(p => p.Ativo).IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
        }


        /*
         * 
         * 
CREATE TABLE Produto (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    Nome NVARCHAR(200) NOT NULL,
    Descricao NVARCHAR(500) NULL,
    Preco DECIMAL(18,2) NOT NULL,
    Quantidade INT NOT NULL,
    Ativo BIT NOT NULL DEFAULT 1,
    DataCadastro DATETIME NOT NULL DEFAULT GETDATE()
);

         */
    }
}
