using Finnova.Core.Models;
using Finnova.Data.Seeds;
using FinnovaWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FinnovaWebApplication.Data
{
    public class FinnovaWebApplicationContext : DbContext
    {
        public FinnovaWebApplicationContext(DbContextOptions<FinnovaWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Banco> Banco { get; set; } = default!;
        public DbSet<Categoria> Categoria { get; set; } = default!;
        public DbSet<Conta> Conta { get; set; } = default!;
        public DbSet<LogAuditoria> LogAuditoria { get; set; } = default!;
        public DbSet<Subcategoria> Subcategoria { get; set; } = default!;
        public DbSet<Transacao> Transacao { get; set; } = default!;
        public DbSet<Transferencia> Transferencia { get; set; } = default!;
        public DbSet<Usuario> Usuario { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BankSeed.SeedBanks(modelBuilder);

            // ---------- Transferencia ----------
            modelBuilder.Entity<Transferencia>()
                .HasOne(t => t.ContaOrigem)
                .WithMany(c => c.TransferenciasOrigem)
                .HasForeignKey(t => t.IdContaOrigem)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transferencia>()
                .HasOne(t => t.ContaDestino)
                .WithMany(c => c.TransferenciasDestino)
                .HasForeignKey(t => t.IdContaDestino)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transferencia>()
                .HasOne<Usuario>()
                .WithMany(u => u.Transferencias)
                .HasForeignKey("UsuarioIdUsuario")
                .OnDelete(DeleteBehavior.SetNull);

            // ---------- Transacao ----------
            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.Conta)
                .WithMany(c => c.Transacoes)
                .HasForeignKey(t => t.IdConta)
                .OnDelete(DeleteBehavior.Restrict); // essencial

            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Transacoes)
                .HasForeignKey(t => t.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.Categoria)
                .WithMany(c => c.Transacoes)
                .HasForeignKey(t => t.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.Subcategoria)
                .WithMany(s => s.Transacoes)
                .HasForeignKey(t => t.IdSubcategoria)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- Categoria ----------
            modelBuilder.Entity<Categoria>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Categorias)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- Conta ----------
            modelBuilder.Entity<Conta>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Contas)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Conta>()
                .HasOne(c => c.Banco)
                .WithMany(b => b.Contas)
                .HasForeignKey(c => c.IdBanco)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- Subcategoria ----------
            modelBuilder.Entity<Subcategoria>()
                .HasOne(s => s.Categoria)
                .WithMany(c => c.Subcategorias)
                .HasForeignKey(s => s.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- LogAuditoria ----------
            modelBuilder.Entity<LogAuditoria>()
                .HasOne(l => l.Usuario)
                .WithMany(u => u.LogsAuditoria)
                .HasForeignKey(l => l.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TipoConta>().HasData(
                new TipoConta { IdTipoConta = 1, DescricaoTipoConta = "Conta Corrente" },
                new TipoConta { IdTipoConta = 2, DescricaoTipoConta = "Conta Poupança" },
                new TipoConta { IdTipoConta = 3, DescricaoTipoConta = "Carteira Digital" },
                new TipoConta { IdTipoConta = 4, DescricaoTipoConta = "Conta de Pagamento" },
                new TipoConta { IdTipoConta = 5, DescricaoTipoConta = "Investimentos" });

            modelBuilder.Entity<TipoInvestimento>().HasData(
                new TipoInvestimento { IdTipoInvestimento = 1, DescricaoTipoInvestimento = "Renda Fixa" },
                new TipoInvestimento { IdTipoInvestimento = 2, DescricaoTipoInvestimento = "Tesouro Direto" },
                new TipoInvestimento { IdTipoInvestimento = 3, DescricaoTipoInvestimento = "CDB" },
                new TipoInvestimento { IdTipoInvestimento = 4, DescricaoTipoInvestimento = "Ações" },
                new TipoInvestimento { IdTipoInvestimento = 5, DescricaoTipoInvestimento = "Fundos Imobiliários (FIIs)" },
                new TipoInvestimento { IdTipoInvestimento = 6, DescricaoTipoInvestimento = "Criptoativos" }
);

        }
        public DbSet<TipoConta> TipoConta { get; set; } = default!;
        public DbSet<TipoTransacao> TipoTransacao { get; set; } = default!;
        public DbSet<Finnova.Core.Models.Empresa> Empresa { get; set; } = default!;
        public DbSet<FinnovaWebApplication.Models.TipoInvestimento> TipoInvestimento { get; set; } = default!;

    }
}
