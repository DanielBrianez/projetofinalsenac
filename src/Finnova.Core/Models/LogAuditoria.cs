using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finnova.Core.Models;

namespace Finnova.Core.Models
{
    [Table("LogAuditoria")]
    public class LogAuditoria
    {
        [Key]
        public int IdLog { get; set; }

        // FK → Usuario (quem realizou a ação)
        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario? Usuario { get; set; }

        // Data e hora exata da ação
        [Required]
        public DateTime DataHora { get; set; } = DateTime.UtcNow;

        // Qual entidade sofreu alteração? (Usuario, Conta, Transacao, etc.)
        [Required]
        [MaxLength(100)]
        public string Entidade { get; set; } = string.Empty;

        // Qual foi o tipo de ação realizada
        // EX: "CREATE", "UPDATE", "DELETE", "LOGIN", "TRANSFER", "RESET_PASSWORD"
        [Required]
        [MaxLength(50)]
        public string Acao { get; set; } = string.Empty;

        // Identificador do registro alterado
        [Required]
        [MaxLength(50)]
        public string EntidadeId { get; set; } = string.Empty;

        // Estado anterior (JSON)
        [Column(TypeName = "nvarchar(max)")]
        public string? ValorAntigo { get; set; }

        // Estado atual (JSON)
        [Column(TypeName = "nvarchar(max)")]
        public string? ValorNovo { get; set; }

        // IP, dispositivo, agente do navegador (opcional, mas útil)
        [MaxLength(100)]
        public string? IP { get; set; }

        [MaxLength(200)]
        public string? UserAgent { get; set; }
    }
}
