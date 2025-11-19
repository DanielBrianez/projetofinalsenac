namespace FinnovaWebApplication.Enums
{
    /// <summary>
    /// Define o tipo de perfil do usuário no sistema Finnova.
    /// Controla regras de negócio e permissões futuras.
    /// </summary>
    public enum TipoUsuario
    {
        /// <summary>Usuário pessoa física comum.</summary>
        Pessoal = 1,

        /// <summary>Pessoa Jurídica (empresa), mas de pequeno porte.</summary>
        MEI = 2,

        /// <summary>Pessoa Jurídica com estrutura maior, com múltiplas contas e operações mais complexas.</summary>
        Empresarial = 3
    }
}
