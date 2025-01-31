using System.ComponentModel.DataAnnotations;

namespace GestaoPedido.Dominio.Entidade
{
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
        public string Email { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;
    }
}
