using Finnova.Core.Services;
using Finnova.Data.Data;
using Finnova.Data.Services;
using Finnova.Desktop;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

static class Program
{
    [STAThread]
    static void Main()
    {
        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FinnovaWebApplicationContext-12b93600-ede8-4dc1-855a-2180ac31334a;Trusted_Connection=True;TrustServerCertificate=True;", sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
            }));

        services.AddScoped<IUsuarioService, UsuarioService>();

        var provider = services.BuildServiceProvider();

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(new frmLogin(provider.GetRequiredService<IUsuarioService>()));
    }
}
