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
            //builder.Property(e => e.IdPedidoProduto).IsRequired();
            builder.Property(e => e.QuantidadeProduzida).IsRequired();
            builder.Property(e => e.DataCadastro).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.DataAlteracao).IsRequired(false);
            //builder.HasIndex(e => new { e.Id, e.IdEtapaProducao, e.IdPedidoProduto }).IsUnique();

          //  builder.HasOne(e => e.EtapaProducao).WithMany().HasForeignKey(e => e.IdEtapaProducao).OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(e => e.PedidoProduto).WithMany().HasForeignKey(e => e.IdPedidoProduto).OnDelete(DeleteBehavior.Restrict);
        }


        /*
         * 
         * 
PRINT 'Criando tabela EtapaProducaoProduto'
GO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'EtapaProducaoProduto' AND type = 'U')
BEGIN
    CREATE TABLE EtapaProducaoProduto
    (
        Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
        IdEtapaProducao UNIQUEIDENTIFIER NOT NULL,
        IdPedidoProduto UNIQUEIDENTIFIER NOT NULL,
        QuantidadeProduzida INT NOT NULL,
        DataCadastro DATETIME NOT NULL DEFAULT GETDATE(),
        DataAlteracao DATETIME NULL,

        CONSTRAINT PK_EtapaProducaoProduto PRIMARY KEY (Id),
        CONSTRAINT FK_EtapaProducaoProduto_EtapaProducao FOREIGN KEY (IdEtapaProducao) REFERENCES EtapaProducao(Id),
        CONSTRAINT FK_EtapaProducaoProduto_PedidoProduto FOREIGN KEY (IdPedidoProduto) REFERENCES PedidoProduto(Id),
        CONSTRAINT UQ_EtapaProducaoProduto UNIQUE (Id, IdEtapaProducao, IdPedidoProduto)
    );
END
ELSE
BEGIN
    PRINT '--> Tabela EtapaProducaoProduto já existe.'
END
GO

         * 
         */
    }
}
