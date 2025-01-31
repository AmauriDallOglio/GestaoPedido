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
            builder.Property(u => u.Email).HasColumnType("varchar").HasMaxLength(250).IsRequired(true);
            builder.Property(t => t.Ativo).HasColumnName("Ativo").IsRequired(true);
        }

    }
}
