using Finnova.Core.Models;

namespace Finnova.Core.Services
{
    public interface IUsuarioService
    {
        Task<bool> LoginAsync(string email, string senha);
        Task<bool> CadastrarAsync(Usuario usuario);
    }

}
