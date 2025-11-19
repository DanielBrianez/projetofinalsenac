using Finnova.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace FinnovaWebApplication.Models
{
    public class TipoUsuario
    {
        [Key]
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "A descrição do tipo de usuário é obrigatória.")]
        [MaxLength(100, ErrorMessage = "A descrição do tipo de usuário deve ter no máximo 100 caracteres.")]
        public string DescricaoTipoUsuario { get; set; } = string.Empty;

        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
