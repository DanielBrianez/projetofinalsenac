using Finnova.Core.Models;
using Finnova.Core.Services;
using Finnova.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Finnova.Data.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> LoginAsync(string email, string senha)
        {
            return await _context.Usuario
                .AnyAsync(x => x.Email == email && x.SenhaHash == senha);
        }

        public async Task<bool> CadastrarAsync(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
