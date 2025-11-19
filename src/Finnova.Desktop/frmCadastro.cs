using Finnova.Core.Models;        
using Finnova.Core.Enums;         
using Finnova.Data.Data;          
using Finnova.Data.Services;      
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace FinnovaDesktopUI
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            //// 1. Validação Simples (Verifica se as senhas batem)
            //if (txtSenha.Text != txtConfirmarSenha.Text)
            //{
            //    MessageBox.Show("As senhas não coincidem!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=FinnovaWebApplicationContext-12b93600-ede8-4dc1-855a-2180ac31334a;Trusted_Connection=True;TrustServerCertificate=True;";
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            try
            {
                using (var context = new AppDbContext(optionsBuilder.Options))
                {
                    var usuarioService = new UsuarioService(context);

                    var novoUsuario = new Usuario
                    {
                        Nome = txtNome.Text,
                        Email = txtEmail.Text,
                        SenhaHash = txtSenha.Text, 
                        TipoUsuario = TipoUsuario.Pessoal,
                        //DataNascimento = dtpDataNascimento.Value
                    };

                    // 5. Chamar o Cadastro
                    bool sucesso = await usuarioService.CadastrarAsync(novoUsuario);

                    if (sucesso)
                    {
                        MessageBox.Show("Conta criada com sucesso!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao criar conta. Tente outro e-mail.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro técnico: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}