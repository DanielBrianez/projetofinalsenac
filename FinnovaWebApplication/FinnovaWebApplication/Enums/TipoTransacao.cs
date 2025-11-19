namespace FinnovaWebApplication.Enums
{
    /// <summary>
    /// Representa o tipo da transação financeira realizada em uma conta.
    /// </summary>
    public enum TipoTransacao
    {
        /// <summary>Entrada de dinheiro (ex.: salário, vendas, recebíveis).</summary>
        Entrada = 1,

        /// <summary>Saída de dinheiro (ex.: compras, contas, despesas em geral).</summary>
        Despesa = 2,

        /// <summary>Transação futura, agendada ou ainda não compensada.</summary>
        Pendente = 3,

        /// <summary>Lançamentos recorrentes automáticos.</summary>
        Recorrente = 4
    }
}
