using Finnova.Core.Models;
using Finnova.Core.Services;
using Finnova.Core.Enums;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace FinnovaDesktopUI
{
    public partial class frmCadastro2 : Form
    {
        private readonly IUsuarioService _usuarioService;

        public frmCadastro2(IUsuarioService usuarioService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
        }

        public frmCadastro2()
        {
            InitializeComponent();
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validações Visuais
                if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtSenha.Text) ||
                    string.IsNullOrWhiteSpace(txtCpf.Text))
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios (Nome, Email, CPF, Senha).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Validar Senhas Iguais
                if (txtSenha.Text != txtConfirmarSenha.Text)
                {
                    MessageBox.Show("As senhas digitadas não conferem!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Preparar Dados (Hash e Salt)
                CriarHashSenha(txtSenha.Text, out byte[] senhaHash, out byte[] senhaSalt);

                // 4. Criar o Objeto Usuario
                var novoUsuario = new Usuario
                {
                    // Concatena Nome + Sobrenome para caber no campo "Nome" do banco
                    Nome = $"{txtNome.Text.Trim()}",

                    Email = txtEmail.Text.Trim(),

                    // Remove pontuação do CPF para salvar em 'Documento'
                    Documento = txtCpf.Text.Replace(".", "").Replace("-", "").Trim(),

                    // Define as senhas criptografadas (Convertendo bytes para string base64 para salvar no banco)
                    SenhaHash = Convert.ToBase64String(senhaHash),
                    SenhaSalt = Convert.ToBase64String(senhaSalt),

                    TipoUsuario = TipoUsuario.Pessoal, // Padrão definido
                    Ativo = true,
                    DataCriacao = DateTime.UtcNow,

                    // Campos opcionais ou nulos
                    NomeEmpresa = null,
                    DataAtualizacao = null
                };

                await _usuarioService.AdicionarUsuario(novoUsuario);

                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar cadastro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para criptografar a senha (compatível com Hash/Salt do modelo)
        private void CriarHashSenha(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                senhaSalt = hmac.Key; // A chave aleatória serve como Salt
                senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            }
        }

        private void lblJaTenhoConta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}