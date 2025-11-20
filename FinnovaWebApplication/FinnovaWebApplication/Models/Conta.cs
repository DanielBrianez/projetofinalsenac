using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinnovaWebApplication.Models;

namespace Finnova.Core.Models
{
    [Table("Conta")]
    public class Conta
    {
        [Key]
        public int IdConta { get; set; }

        // FK obrigatória: Usuário
        [Required]
        [Display(Name = "Usuário responsável")]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; } = null!;

        // FK Banco
        [Required]
        [Display(Name = "Banco")]
        [ForeignKey("Banco")]
        public int IdBanco { get; set; }
        public Banco Banco { get; set; } = null!;

        // Nome da conta
        [Required(ErrorMessage = "O nome da conta é obrigatório.")]
        [Display(Name = "Nome da Conta")]
        [MaxLength(60)]
        public string NomeConta { get; set; } = string.Empty;

        // Tipo Conta — CORRIGIDO!
        [Required(ErrorMessage = "O tipo da conta é obrigatório.")]
        [Display(Name = "Tipo da Conta")]
        [ForeignKey("TipoConta")]
        public int IdTipoConta { get; set; }
        public TipoConta TipoConta { get; set; } = null!;

        // Tipo de Investimento (Opcional)
        [Display(Name = "Tipo de Investimento")]
        [ForeignKey("TipoInvestimento")]
        public int? IdTipoInvestimento { get; set; }
        public TipoInvestimento? TipoInvestimento { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Saldo Inicial")]
        public decimal SaldoInicial { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Saldo Atual")]
        public decimal SaldoAtual { get; set; }

        [Required]
        [Display(Name = "Data de Criacao")]
        [Column(TypeName = "datetime2")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public bool Ativo { get; set; } = true;

        // Navegações
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();

        [InverseProperty("ContaOrigem")]
        [Display(Name = "Conta de Origem")]
        public ICollection<Transferencia> TransferenciasOrigem { get; set; } = new List<Transferencia>();

        [InverseProperty("ContaDestino")]
        [Display(Name = "Conta de Destino")]
        public ICollection<Transferencia> TransferenciasDestino { get; set; } = new List<Transferencia>();
    }
}
