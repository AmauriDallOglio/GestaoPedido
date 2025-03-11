using System.ComponentModel;

namespace GestaoPedido.Dominio.Util
{
    public class Enums
    {
        public enum SituacaoPedido
        {
            [Description("Pendente")]
            Pendente = 0,

            [Description("Aguardando Pagamento")]
            AguardandoPagamento = 1,

            [Description("Aprovado")]
            Aprovado = 2,

            [Description("Pagamento Recusado")]
            PagamentoRecusado = 3,

            [Description("Em Separação")]
            EmSeparacao = 4,

            [Description("Enviado")]
            Enviado = 5,

            [Description("Entregue")]
            Entregue = 6,

            [Description("Cancelado")]
            Cancelado = 7,

            [Description("Devolvido")]
            Devolvido = 8,

            [Description("Reembolsado")]
            Reembolsado = 9
        }
    }

}
