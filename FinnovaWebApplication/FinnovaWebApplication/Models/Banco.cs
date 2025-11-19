using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finnova.Core.Models
{
    [Table("Banco")]
    public class Banco
    {
        [Key]
        public int IdBanco { get; set; }

        [Required]
        [MaxLength(4)]
        [Display(Name = "Código")]
        public string Codigo { get; set; } = string.Empty; // Ex.: 001, 237, 260, etc.

        [Required]
        [MaxLength(80)]
        [Display(Name = "Instituição")]
        public string Nome { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;

        // Relação: 1 Banco → N Contas
        public ICollection<Conta> Contas { get; set; } = new List<Conta>();
    }
}
