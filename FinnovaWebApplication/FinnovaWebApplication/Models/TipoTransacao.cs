using System.ComponentModel.DataAnnotations;

namespace FinnovaWebApplication.Models
{
    public class TipoTransacao
    {
        [Key]
        public int IdTipoTransacao { get; set; }

        [Required(ErrorMessage = "A descrição do tipo de transação é obrigatória.")]
        [MaxLength(100, ErrorMessage = "A descrição do tipo de transação deve ter no máximo 100 caracteres.")]
        public string DescricaoTipoTransacao { get; set; } = string.Empty;

        public virtual ICollection<Transacao>? Transacoes { get; set; }
    }
}
