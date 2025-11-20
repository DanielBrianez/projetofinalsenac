using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinnovaWebApplication.Models;

namespace Finnova.Core.Models
{
    [Table("CategoriaDeGasto")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        // FK obrigatória: 1 Usuario → N Categorias
        [Required]
        [Display(Name = "Usuário responsável")]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [Display(Name = "Nome da Categoria")]
        [MaxLength(60)]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Descrição da categoria")]
        [MaxLength(200)]
        public string? Descricao { get; set; }

        [Required]
        [Display(Name = "Data de criação da categoria")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public bool Ativo { get; set; } = true;

        // Navegações
        public Usuario Usuario { get; set; } = null!;
        public ICollection<Subcategoria> Subcategorias { get; set; } = new List<Subcategoria>();

        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
