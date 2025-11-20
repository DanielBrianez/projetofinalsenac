using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finnova.Core.Models;

namespace FinnovaWebApplication.Models
{
    [Table("Transferencias")]
    public class Transferencia
    {
        [Key]
        public int IdTransferencia { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataTransferencia { get; set; }

        // FK → Conta de origem
        [Required]
        [ForeignKey("ContaOrigem")]
        public int IdContaOrigem { get; set; }

        public virtual Conta? ContaOrigem { get; set; }

        // FK → Conta de destino
        [Required]
        [ForeignKey("ContaDestino")]
        public int IdContaDestino { get; set; }

        public virtual Conta? ContaDestino { get; set; }

        // Mensagem/descrição opcional da transferência
        [MaxLength(200)]
        public string? Descricao { get; set; }
    }
}
