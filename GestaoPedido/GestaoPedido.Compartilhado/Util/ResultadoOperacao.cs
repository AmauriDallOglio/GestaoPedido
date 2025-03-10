namespace GestaoPedido.Compartilhado.Util
{
    public class ResultadoOperacao
    {
        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; } = string.Empty;
        public static ResultadoOperacao CriarSucesso(string mensagem) => new() { Sucesso = true, Mensagem = mensagem };
        public static ResultadoOperacao CriarFalha(string mensagem) => new() { Sucesso = false, Mensagem = mensagem };
    }
}
