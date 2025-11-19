using Finnova.Core.Services;
using Finnova.Data.Data;
using Finnova.Data.Services;
using FinnovaDesktopUI;
using Microsoft.EntityFrameworkCore;


namespace Finnova.Desktop
{
    public partial class frmLogin : Form
    {
        private readonly IUsuarioService _usuarioService;

        public frmLogin(IUsuarioService usuarioService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
        }


        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=FinnovaWebApplicationContext-12b93600-ede8-4dc1-855a-2180ac31334a;Trusted_Connection=True;TrustServerCertificate=True;";
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            try
            {
                using (var context = new AppDbContext(optionsBuilder.Options))
                {
                    var usuarioService = new UsuarioService(context);

                    bool loginSucesso = await usuarioService.LoginAsync(txtLogin.Text, txtSenha.Text);

                    if (loginSucesso)
                    {
                        MessageBox.Show("Login realizado com sucesso!");
                        // FrmPrincipal p = new FrmPrincipal(); p.Show(); this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login inválido.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void lblCadastro_Click(object sender, EventArgs e)
        {
            using (frmCadastro formCadastro = new frmCadastro())
            {
                formCadastro.ShowDialog();
            }
        }
    }
}