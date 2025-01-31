using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Infraestrutura.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Contexto
{
    public class GenericoContexto : DbContext
    {
        public DbSet<Cliente> ClienteDb { get; set; }
 
        public GenericoContexto(DbContextOptions<GenericoContexto> options) : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteMapeamento());

        }
    }
}
