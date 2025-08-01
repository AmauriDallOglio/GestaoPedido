﻿namespace GestaoPedido.Aplicacao.Dto
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }

    public class ClienteFiltro
    {
        public string FiltroNome { get; set; } = string.Empty;
    }


}
