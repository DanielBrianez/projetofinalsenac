using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinnovaWebApplication.Models;

namespace Finnova.Core.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public Usuario()
        {
            DataCriacao = DateTime.UtcNow; // valor padrão automático
        }

        [Key]
        public int IdUsuario { get; set; }

        // Dados básicos
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name = "Nome completo")]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [Display(Name = "E-mail")]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; } = string.Empty;

        // Segurança
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [MaxLength(512)]
        public string SenhaHash { get; set; } = string.Empty;

        // Documento
        [Display(Name = "Documento CPF")]
        [MaxLength(18)]
        public string? Documento { get; set; }

        // Campos específicos
        [Display(Name = "Data de nascimento")]
        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        // Auditoria
        [Display(Name = "Data de criação")]
        [Column(TypeName = "datetime2")]
        public DateTime DataCriacao { get; set; }

        public bool Ativo { get; set; } = true;

        // Navegações 1:N
        public ICollection<Conta> Contas { get; set; } = new List<Conta>();
        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
        public ICollection<Transferencia> Transferencias { get; set; } = new List<Transferencia>();
        public ICollection<LogAuditoria> LogsAuditoria { get; set; } = new List<LogAuditoria>();
    }
}
