using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finnova.Core.Models;

namespace FinnovaWebApplication.Models
{
    [Table("Transacao")]
    public class Transacao
    {
        [Key]
        public int IdTransacao { get; set; }

        [Required(ErrorMessage = "O valor da transação é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data da transação é obrigatória.")]
        [Display(Name = "Data da Transação")]
        public DateTime DataTransacao { get; set; }

        // Tipo da transação (Entrada/Saída)
        [Required(ErrorMessage = "O tipo da transação é obrigatório.")]
        [ForeignKey(nameof(TipoTransacao))]
        [Display(Name = "Tipo da Transação")]
        public int IdTipoTransacao { get; set; }
        public virtual TipoTransacao TipoTransacao { get; set; } = null!;

        // Usuário responsável
        [Required]
        [ForeignKey(nameof(Usuario))]
        [Display(Name = "Usuário responsável")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; } = null!;

        // Conta utilizada
        [Required]
        [ForeignKey(nameof(Conta))]
        [Display(Name = "Conta")]
        public int IdConta { get; set; }
        public virtual Conta Conta { get; set; } = null!;

        // Categoria
        [Required(ErrorMessage = "A categoria da transação é obrigatória.")]
        [ForeignKey(nameof(Categoria))]
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; } = null!;

        // Subcategoria (opcional)
        [ForeignKey(nameof(Subcategoria))]
        [Display(Name = "Subcategoria")]
        public int? IdSubcategoria { get; set; }
        public virtual Subcategoria? Subcategoria { get; set; }

        // Descrição opcional
        [MaxLength(200)]
        [Display(Name = "Descrição da transação")]
        public string? Descricao { get; set; }
    }
}
