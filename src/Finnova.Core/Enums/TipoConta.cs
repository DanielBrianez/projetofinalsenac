namespace Finnova.Core.Enums
{
    /// <summary>
    /// Define os tipos de contas disponíveis no sistema Finnova.
    /// </summary>
    public enum TipoConta
    {
        Carteira = 1,           // dinheiro físico
        ContaCorrente = 2,      // banco tradicional
        Poupanca = 3,           // reserva
        ContaDigital = 4,       // Nubank, Inter, Next, etc
        Credito = 5,            // cartões
        Outros = 6
    }

}
