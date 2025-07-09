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
            builder.HasIndex(f => f.Documento).IsUnique().HasDatabaseName("UQ_Fornecedor_Documento");
            builder.Property(f => f.Inativo).IsRequired().HasDefaultValue(false);
        }
    }
}
