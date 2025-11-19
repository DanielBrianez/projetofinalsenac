using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finnova.Core.Models;

namespace Finnova.Core.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        // FK obrigatória: 1 Usuario → N Categorias
        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [Display(Name = "Nome da Categoria")]
        [MaxLength(60)]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        [MaxLength(200)]
        public string? Descricao { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public DateTime? DataAtualizacao { get; set; }

        public bool Ativo { get; set; } = true;

        // Navegações
        public Usuario Usuario { get; set; } = null!;
        public ICollection<Subcategoria> Subcategorias { get; set; } = new List<Subcategoria>();

        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
