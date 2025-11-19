using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinnovaWebApplication.Enums;
using FinnovaWebApplication.Models;

namespace Finnova.Core.Models
{
    [Table("Conta")]
    public class Conta
    {
        [Key]
        public int IdConta { get; set; }

        // FK obrigatória: 1 Usuario → N Contas
        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; } = null!;

        // 🔥 FK para Banco (nova)
        [Required]
        [ForeignKey("Banco")]
        public int IdBanco { get; set; }
        public Banco Banco { get; set; } = null!;

        [Required(ErrorMessage = "O nome da conta é obrigatório.")]
        [Display(Name = "Nome da Conta")]
        [MaxLength(60)]
        public string NomeConta { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Tipo da Conta")]
        public TipoConta Tipo { get; set; } = TipoConta.ContaCorrente;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Saldo Inicial")]
        public decimal SaldoInicial { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Saldo Atual")]
        public decimal SaldoAtual { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime2")]
        public DateTime? DataAtualizacao { get; set; }

        public bool Ativo { get; set; } = true;

        // Navegação: 1 Conta → N Transações
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();

        // Navegação: 1 Conta → N Transferências (origem)
        [InverseProperty("ContaOrigem")]
        public ICollection<Transferencia> TransferenciasOrigem { get; set; } = new List<Transferencia>();

        // Navegação: 1 Conta → N Transferências (destino)
        [InverseProperty("ContaDestino")]
        public ICollection<Transferencia> TransferenciasDestino { get; set; } = new List<Transferencia>();
    }
}
