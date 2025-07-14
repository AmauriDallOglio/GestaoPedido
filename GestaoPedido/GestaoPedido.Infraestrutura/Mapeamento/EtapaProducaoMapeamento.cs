using GestaoPedido.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPedido.Infraestrutura.Mapeamento
{
    public class EtapaProducaoMapeamento : IEntityTypeConfiguration<EtapaProducao>
    {
        public void Configure(EntityTypeBuilder<EtapaProducao> builder)
        {
            builder.ToTable("EtapaProducao");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(e => e.IdPedido).IsRequired();
            builder.Property(e => e.IdFornecedor).IsRequired(false);
            builder.Property(e => e.Descricao).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(e => e.Quantidade).IsRequired();
            builder.Property(e => e.DataInicialFabricacao).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.DataFinalFabricacao).IsRequired(false);
            builder.Property(e => e.Situacao).IsRequired().HasDefaultValue((byte)0);
            builder.Property(e => e.DataCadastro).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.DataAlteracao).IsRequired(false);

            builder.HasOne(e => e.Pedido).WithMany().HasForeignKey(e => e.IdPedido).OnDelete(DeleteBehavior.Restrict).HasConstraintName("FK_EtapaProducao_Pedido");
            builder.HasOne(e => e.Fornecedor).WithMany().HasForeignKey(e => e.IdFornecedor).OnDelete(DeleteBehavior.Restrict).HasConstraintName("FK_EtapaProducao_Fornecedor");
            builder.HasIndex(e => new { e.IdPedido, e.IdFornecedor }).IsUnique().HasDatabaseName("UQ_EtapaProducao");
        }
    }
}
