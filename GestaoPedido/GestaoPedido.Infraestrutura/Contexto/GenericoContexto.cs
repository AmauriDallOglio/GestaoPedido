using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Infraestrutura.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Contexto
{
    public class GenericoContexto : DbContext
    {
        public DbSet<Cliente> ClienteDb { get; set; }
        public DbSet<Produto> ProdutoDb { get; set; }
        public DbSet<Pedido> PedidoDb { get; set; }
        public DbSet<PedidoProduto> PedidoProdutoDb { get; set; }

        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<EtapaProducao> EtapaProducao { get; set; }

        public GenericoContexto(DbContextOptions<GenericoContexto> options) : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
            modelBuilder.ApplyConfiguration(new ProdutoMapeamento());
            modelBuilder.ApplyConfiguration(new PedidoMapeamento());
            modelBuilder.ApplyConfiguration(new PedidoProdutoMapeamento());
            modelBuilder.ApplyConfiguration(new FornecedorMapeamento());

        }
    }
}
