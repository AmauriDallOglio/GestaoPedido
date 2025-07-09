using System.ComponentModel.DataAnnotations;

namespace GestaoPedido.Dominio.Entidade
{
    public class Cliente
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
        public string Email { get; set; } = string.Empty;

        public bool Inativo { get; set; } = false;

        public Cliente() { }

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }


    }
}
