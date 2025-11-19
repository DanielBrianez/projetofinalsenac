using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinnovaWebApplication.Enums;
using FinnovaWebApplication.Models;

namespace Finnova.Core.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome completo")]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "E-mail")]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; } = string.Empty;

        // Armazenar hash + salt
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [MaxLength(512)]
        public string SenhaHash { get; set; } = string.Empty;

        [Required]
        [MaxLength(512)]
        public string SenhaSalt { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Tipo de Usuário")]
        public TipoUsuario TipoUsuario { get; set; } = TipoUsuario.Pessoal;

        [Display(Name = "Documento (CPF/CNPJ)")]
        [MaxLength(18)]
        public string? Documento { get; set; }

        [Display(Name = "Nome da Empresa")]
        [MaxLength(100)]
        public string? NomeEmpresa { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime2")]
        public DateTime? DataAtualizacao { get; set; }

        public bool Ativo { get; set; } = true;

        // Navegações (1:N)
        public ICollection<Conta> Contas { get; set; } = new List<Conta>();

        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();

        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();

        public ICollection<Transferencia> Transferencias { get; set; } = new List<Transferencia>();

        public ICollection<LogAuditoria> LogsAuditoria { get; set; } = new List<LogAuditoria>();

    }
}
