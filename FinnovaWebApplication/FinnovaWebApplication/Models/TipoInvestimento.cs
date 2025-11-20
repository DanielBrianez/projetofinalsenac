using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finnova.Core.Models;

namespace FinnovaWebApplication.Models
{
    [Table("TipoInvestimento")]
    public class TipoInvestimento
    {
        [Key]
        public int IdTipoInvestimento { get; set; }

        [Required(ErrorMessage = "A descrição do tipo de investimento é obrigatória.")]
        [MaxLength(100)]
        public string DescricaoTipoInvestimento { get; set; } = string.Empty;

        // Relacionamento 1:N
        public ICollection<Conta> Contas { get; set; } = new List<Conta>();
    }
}
