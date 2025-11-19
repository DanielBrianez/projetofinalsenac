using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finnova.Core.Enums;

namespace Finnova.Core.Models
{
    public class Transacao
    {
        [Key]
        public int IdTransacao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataTransacao { get; set; }

        [Required]
        public TipoTransacao Tipo { get; set; }  // Entrada / Saída

        // FK → Usuario (ESSENCIAL)
        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario? Usuario { get; set; }

        // FK → Conta
        [Required]
        [ForeignKey("Conta")]
        public int IdConta { get; set; }
        public virtual Conta? Conta { get; set; }

        // FK → Categoria
        [Required]
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }
        public virtual Categoria? Categoria { get; set; }

        // FK → Subcategoria (opcional)
        [ForeignKey("Subcategoria")]
        public int? IdSubcategoria { get; set; }
        public virtual Subcategoria? Subcategoria { get; set; }

        // Descrição opcional
        [MaxLength(200)]
        public string? Descricao { get; set; }

        // Auditoria
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime? AtualizadoEm { get; set; }
    }
}
