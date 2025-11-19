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

        // =======================
        //  FK → Usuário (Obrigatória)
        // =======================
        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; } = null!;

        // =======================
        //  FK → Banco (Obrigatória)
        // =======================
        [Required(ErrorMessage = "O banco é obrigatório.")]
        [ForeignKey(nameof(Banco))]
        public int IdBanco { get; set; }
        public Banco Banco { get; set; } = null!;

        // =======================
        //  FK → TipoConta (Obrigatória)
        // =======================
        [Required(ErrorMessage = "O tipo da conta é obrigatório.")]
        [ForeignKey(nameof(TipoConta))]
        public int IdTipoConta { get; set; }
        public TipoConta TipoConta { get; set; } = null!;

        // =======================
        //  Campos principais
        // =======================
        [Required(ErrorMessage = "O nome da conta é obrigatório.")]
        [MaxLength(60, ErrorMessage = "O nome da conta deve ter no máximo 60 caracteres.")]
        [Display(Name = "Nome da Conta")]
        public string NomeConta { get; set; } = string.Empty;

        [Required(ErrorMessage = "O saldo inicial é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Saldo Inicial")]
        public decimal SaldoInicial { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Saldo Atual")]
        public decimal SaldoAtual { get; set; }

        // =======================
        //  Datas
        // =======================
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime2")]
        public DateTime? DataAtualizacao { get; set; }

        public bool Ativo { get; set; } = true;

        // =======================
        //  Navegações
        // =======================
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();

        [InverseProperty(nameof(Transferencia.ContaOrigem))]
        public ICollection<Transferencia> TransferenciasOrigem { get; set; } = new List<Transferencia>();

        [InverseProperty(nameof(Transferencia.ContaDestino))]
        public ICollection<Transferencia> TransferenciasDestino { get; set; } = new List<Transferencia>();
    }
}
