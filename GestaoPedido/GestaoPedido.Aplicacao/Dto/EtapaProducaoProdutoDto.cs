using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPedido.Aplicacao.Dto
{
    public class EtapaProducaoProdutoDto
    {
    }


    public class IndexParametro()
    {
        public Guid IdEtapaProducaoParametro { get; set; }
        public Guid IdPedidoParametro { get; set; }
        public string CodigoPedidoParametro { get; set; } = string.Empty;
    }


    public class EtapaProducaoProdutoIncluirDto
    {


        [Required(ErrorMessage = "O campo 'Etapa de Produção' é obrigatório.")]
        public Guid IdEtapaProducao { get; set; }

        public string CodigoPedido { get; set; } = string.Empty;

        public Guid IdPedido { get; set; }
        [Required(ErrorMessage = "O campo 'Produto' é obrigatório.")]
        public Guid? IdProduto { get; set; }

        [Required(ErrorMessage = "O campo 'Pedido Produto' é obrigatório.")]
        public Guid IdPedidoProduto { get; set; }

        [Required(ErrorMessage = "O campo 'Quantidade Produzida' é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade produzida deve ser maior que zero.")]
        public int? QuantidadeProduzida { get; set; }






    }


    public class EtapaProducaoProdutoObterTodosDto
    {
        public Guid Id { get; set; }

        public Guid IdEtapaProducao { get; set; }

        public Guid IdPedidoProduto { get; set; }

        public int QuantidadeProduzida { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }


        public string CodigoPedido { get; set; } = string.Empty;
        public string NomeProduto { get; set; } = string.Empty;

        public string? DescricaoProduto { get; set; }




    }




    public class EtapaProducaoProdutoExcluirDto
    {

        public Guid Id { get; set; }
        public Guid IdEtapaProducao { get; set; }
        public string NomeProduto { get; set; } = string.Empty ;

    }


}
