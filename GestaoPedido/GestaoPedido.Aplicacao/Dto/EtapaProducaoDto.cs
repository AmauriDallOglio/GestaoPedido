using GestaoPedido.Dominio.Entidade;
using System.ComponentModel.DataAnnotations;

namespace GestaoPedido.Aplicacao.Dto
{
    public class EtapaProducaoDto
    {
        public Guid Id { get; set; }
        public Guid IdPedido { get; set; }
        public Guid? IdFornecedor { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public int QuantidadeProduzida { get; set; }
        public decimal PercentualProduzida { get; set; }
        public DateTime DataInicialFabricacao { get; set; } = DateTime.Now;
        public DateTime? DataFinalFabricacao { get; set; }
        public byte Situacao { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }
        public String CodigoPedido { get; set; } = String.Empty;

        public EtapaProducaoDto ConverterEtapaProducao(EtapaProducao etapaProducao, DateTime dataUltimaAtualizacao, int quantidadeProduzida)
        {
            QuantidadeProduzida = quantidadeProduzida;
            Id = etapaProducao.Id;
            Descricao = etapaProducao.Descricao;
            Quantidade = etapaProducao.Quantidade;
            PercentualProduzida = etapaProducao.Quantidade > 0 ? (int)Math.Round((decimal)quantidadeProduzida / etapaProducao.Quantidade * 100) : 0;
            IdFornecedor = etapaProducao.IdFornecedor;
            IdPedido = etapaProducao.IdPedido;
            DataInicialFabricacao = etapaProducao.DataInicialFabricacao;
            DataFinalFabricacao = etapaProducao.DataFinalFabricacao;
            DataCadastro = etapaProducao.DataCadastro;
            DataAlteracao = etapaProducao.DataAlteracao;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            CodigoPedido = etapaProducao.Pedido.NumeroPedido;
            Situacao = etapaProducao.Situacao;

            return this;
        }
 
    }

    public class EtapaProducaoFiltro()
    {
        public string FiltroPedido { get; set; } = string.Empty ;
        public int? FiltroSituacao { get; set; }
    }


    public class EtapaProducaoIncluirNoPedidoDto()
    {
        public Guid IdPedido { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(100, ErrorMessage = "A descrição não pode exceder 100 caracteres.")]
        public string Descricao { get; set; } = string.Empty;
        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }
        public DateTime DataInicialFabricacao { get; set; } = DateTime.Now;
        public Guid? IdFornecedor { get; set; }

        public EtapaProducaoIncluirNoPedidoDto Incluir(Guid idPedido, string descricao, int quantidade, DateTime dataInicialFabricacao, Guid? idFornecedor)
        {
            IdPedido = idPedido;
            Descricao = descricao;
            Quantidade = quantidade;
            DataInicialFabricacao = dataInicialFabricacao;
            IdFornecedor = idFornecedor;
            return this;
        }
    }

    
 
    public class EtapaProducaoIncluirDto
    {

        [Required(ErrorMessage = "O pedido é obrigatório.")]
        public Guid IdPedido { get; set; }
        public Guid? IdFornecedor { get; set; }

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

    }

    public class EtapaProducaoAlterarDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O pedido é obrigatório.")]
        public Guid IdPedido { get; set; }

        public Guid? IdFornecedor { get; set; }

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
        public DateTime? DataAlteracao { get; set; } = DateTime.Now;

    }

}
