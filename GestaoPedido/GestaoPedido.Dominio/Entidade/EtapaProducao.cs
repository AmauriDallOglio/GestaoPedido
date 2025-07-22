using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoPedido.Dominio.Entidade
{
    public class EtapaProducao
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O pedido é obrigatório.")]
        public Guid IdPedido { get; set; }
        public virtual Pedido Pedido { get; set; }

        public Guid? IdFornecedor { get; set; }
        public virtual Fornecedor? Fornecedor { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(100, ErrorMessage = "A descrição não pode exceder 100 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "A data inicial da fabricação é obrigatória.")]
        public DateTime DataInicialFabricacao { get; set; } = DateTime.Now;

        public DateTime? DataFinalFabricacao { get; set; }

        [Range(0, 255, ErrorMessage = "Situação inválida.")]
        public byte Situacao { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; }

  
        public virtual ICollection<EtapaProducaoProduto> EtapaProducaoProdutos { get; set; } = new List<EtapaProducaoProduto>();

        //public EtapaProducao() { }

        public EtapaProducao AlterarSituacao(byte situacao)
        {
            Situacao = situacao;
            DataAlteracao = DateTime.Now;
            return this;
        }

        public EtapaProducao IncluirNoPedido(Guid idPedido, string descricao, int quantidade, DateTime dataInicialFabricacao, Guid? idFornecedor)
        {
            IdPedido = idPedido;
            Descricao = descricao;
            Quantidade = quantidade;
            DataInicialFabricacao = dataInicialFabricacao;
            IdFornecedor = idFornecedor;
            return this;
        }

        public EtapaProducao Incluir(Guid idPedido, string descricao, int quantidade, DateTime dataInicialFabricacao, Guid? idFornecedor = null)
        {
            Id = Guid.NewGuid();
            IdPedido = idPedido;
            IdFornecedor = idFornecedor;
            Descricao = descricao;
            Quantidade = quantidade;
            DataInicialFabricacao = dataInicialFabricacao;
            Situacao = 0;
            DataCadastro = DateTime.Now;
            return this;
        }

        public void Finalizar(DateTime dataFinal)
        {
            DataFinalFabricacao = dataFinal;
            Situacao = 2; // exemplo: 2 = finalizado
            DataAlteracao = DateTime.Now;
        }

        public void Atualizar(string descricao, int quantidade, DateTime? dataFinal, byte situacao)
        {
            Descricao = descricao;
            Quantidade = quantidade;
            DataFinalFabricacao = dataFinal;
            Situacao = situacao;
            DataAlteracao = DateTime.Now;
        }

    }
}
