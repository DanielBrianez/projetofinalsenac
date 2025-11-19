using Finnova.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace FinnovaWebApplication.Models
{
    public class TipoConta
    {
        [Key]
        public int IdTipoConta { get; set; }

        [Required(ErrorMessage = "A descrição do tipo de conta é obrigatória.")]
        [MaxLength(100, ErrorMessage = "A descrição do tipo de conta deve ter no máximo 100 caracteres.")]
        public string DescricaoTipoConta { get; set; } = string.Empty;

        public virtual ICollection<Conta>? Contas { get; set; }
    }
}
