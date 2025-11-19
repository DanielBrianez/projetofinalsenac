using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finnova.Core.Models;

namespace FinnovaWebApplication.Models
{
    public class Subcategoria
    {
        [Key]
        public int IdSubcategoria { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        // FK → Categoria
        [Required]
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        // Relação muitos-para-um
        public virtual Categoria? Categoria { get; set; }

        // Relação um-para-muitos → Transações
        public virtual ICollection<Transacao>? Transacoes { get; set; }
    }
}
