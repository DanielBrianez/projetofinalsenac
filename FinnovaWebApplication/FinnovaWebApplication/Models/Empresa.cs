using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinnovaWebApplication.Models;

namespace Finnova.Core.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        public Empresa()
        {
            DataCriacao = DateTime.UtcNow; // Valor padrão
        }

        [Key]
        public int IdEmpresa { get; set; }

        // Dados básicos
        [Required(ErrorMessage = "O nome fantasia é obrigatório.")]
        [Display(Name = "Nome fantasia")]
        [MaxLength(100)]
        public string NomeFantasia { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [Display(Name = "E-mail")]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Segurança
        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [MaxLength(512)]
        public string SenhaHash { get; set; } = string.Empty;

        // Documento PJ
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [Display(Name = "CNPJ")]
        [MaxLength(18)]
        public string CNPJ { get; set; } = string.Empty;

        // Novo campo → Data de fundação
        [Required(ErrorMessage = "A data de fundação é obrigatória.")]
        [Display(Name = "Data de fundação")]
        [Column(TypeName = "date")]
        public DateTime DataFundacao { get; set; }

        // Auditoria
        [Display(Name = "Ativo?")]
        public bool Ativo { get; set; } = true;

        [Display(Name = "Data de criação")]
        [Column(TypeName = "datetime2")]
        public DateTime DataCriacao { get; set; }

        // Navegações
        public ICollection<Conta> Contas { get; set; } = new List<Conta>();
        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
        public ICollection<Transferencia> Transferencias { get; set; } = new List<Transferencia>();
        public ICollection<LogAuditoria> LogsAuditoria { get; set; } = new List<LogAuditoria>();
    }
}
