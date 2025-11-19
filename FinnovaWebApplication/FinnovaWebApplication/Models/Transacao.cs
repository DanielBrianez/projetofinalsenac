using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finnova.Core.Models;

namespace FinnovaWebApplication.Models
{
    public class Transacao
    {
        [Key]
        public int IdTransacao { get; set; }

        [Required(ErrorMessage = "O valor da transação é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data da transação é obrigatória.")]
        public DateTime DataTransacao { get; set; }

        // FK → TipoTransacao (Entrada/Saída)
        [Required(ErrorMessage = "O tipo da transação é obrigatório.")]
        [ForeignKey(nameof(TipoTransacao))]
        public int IdTipoTransacao { get; set; }
        public virtual TipoTransacao TipoTransacao { get; set; } = null!;

        // FK → Usuario
        [Required]
        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; } = null!;

        // FK → Conta
        [Required]
        [ForeignKey(nameof(Conta))]
        public int IdConta { get; set; }
        public virtual Conta Conta { get; set; } = null!;

        // FK → Categoria
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        [ForeignKey(nameof(Categoria))]
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; } = null!;

        // FK → Subcategoria (opcional)
        [ForeignKey(nameof(Subcategoria))]
        public int? IdSubcategoria { get; set; }
        public virtual Subcategoria? Subcategoria { get; set; }

        // Descrição (opcional)
        [MaxLength(200)]
        public string? Descricao { get; set; }

        // Auditoria
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime? AtualizadoEm { get; set; }
    }
}
