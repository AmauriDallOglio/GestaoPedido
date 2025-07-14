using GestaoPedido.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPedido.Infraestrutura.Mapeamento
{
    public class EtapaProducaoProdutoMapeamento : IEntityTypeConfiguration<EtapaProducaoProduto>
    {
        public void Configure(EntityTypeBuilder<EtapaProducaoProduto> builder)
        {
            builder.ToTable("EtapaProducaoProduto");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(e => e.IdEtapaProducao).IsRequired();
            builder.Property(e => e.IdPedidoProduto).IsRequired();
            builder.Property(e => e.QuantidadeProduzida).IsRequired();
            builder.Property(e => e.DataCadastro).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.DataAlteracao).IsRequired(false);
            builder.HasIndex(e => new { e.Id, e.IdEtapaProducao, e.IdPedidoProduto }).IsUnique();

            builder.HasOne(e => e.EtapaProducao).WithMany().HasForeignKey(e => e.IdEtapaProducao).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.PedidoProduto).WithMany().HasForeignKey(e => e.IdPedidoProduto).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
