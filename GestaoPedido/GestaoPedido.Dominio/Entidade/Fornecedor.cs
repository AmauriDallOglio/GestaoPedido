using System.ComponentModel.DataAnnotations;

namespace GestaoPedido.Dominio.Entidade
{
    public class Fornecedor
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O campo documento é obrigatório.")]
        [StringLength(20, ErrorMessage = "O documento deve ter no máximo 20 caracteres.")]
        public string Documento { get; set; } = null!;

        [Required(ErrorMessage = "O campo inativo é obrigatório.")]
        public bool Inativo { get; set; }

        public Fornecedor() { }


        public Fornecedor(string nome, string documento)
        {
            Id = Guid.NewGuid();
            DefinirNome(nome);
            DefinirDocumento(documento);
            Inativo = false;
        }


        public void DefinirNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do fornecedor não pode estar vazio.");

            if (nome.Length > 100)
                throw new ArgumentException("Nome do fornecedor não pode ter mais que 100 caracteres.");

            Nome = nome.Trim();
        }

        public void DefinirDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                throw new ArgumentException("Documento do fornecedor não pode estar vazio.");

            if (documento.Length > 20)
                throw new ArgumentException("Documento do fornecedor não pode ter mais que 20 caracteres.");

            Documento = documento.Trim();
        }

        public void Inativar()
        {
            Inativo = true;
        }

        public void Ativar()
        {
            Inativo = false;
        }


    }
}
