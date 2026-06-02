using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace teste_de_designe
{
    public partial class PaginaLogin : Form
    {
        public string emailDoUsuario;

    public PaginaLogin()
        {
            InitializeComponent();

            if (!EstaEmModoDesign())
            {
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                              ControlStyles.AllPaintingInWmPaint |
                              ControlStyles.UserPaint, true);

                this.UpdateStyles();

                panelTransparente1.BackColor = Color.FromArgb(100, 160, 220, 190);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (EstaEmModoDesign())
                return;

            IntPtr hRgn = CreateRoundRectRgn(
                0, 0,
                panelTransparente1.Width,
                panelTransparente1.Height,
                30, 30);

            panelTransparente1.Region = Region.FromHrgn(hRgn);
            DeleteObject(hRgn);

            ArredondarBotao();
            ArredondarTextBox();
        }

        private void ArredondarBotao()
        {
            if (EstaEmModoDesign())
                return;

            IntPtr hRgn;

            hRgn = CreateRoundRectRgn(0, 0, btnCadastrar.Width, btnCadastrar.Height, 20, 20);
            btnCadastrar.Region = Region.FromHrgn(hRgn);
            DeleteObject(hRgn);

            hRgn = CreateRoundRectRgn(0, 0, btnEntrar.Width, btnEntrar.Height, 20, 20);
            btnEntrar.Region = Region.FromHrgn(hRgn);
            DeleteObject(hRgn);

            hRgn = CreateRoundRectRgn(0, 0, btnEsqueciSenha.Width, btnEsqueciSenha.Height, 20, 20);
            btnEsqueciSenha.Region = Region.FromHrgn(hRgn);
            DeleteObject(hRgn);
        }

        private void ArredondarTextBox()
        {
            if (EstaEmModoDesign())
                return;

            IntPtr hRgn;

            hRgn = CreateRoundRectRgn(0, 0, txtE_mail.Width, txtE_mail.Height, 15, 15);
            txtE_mail.Region = Region.FromHrgn(hRgn);
            DeleteObject(hRgn);

            hRgn = CreateRoundRectRgn(0, 0, txtSenha.Width, txtSenha.Height, 15, 15);
            txtSenha.Region = Region.FromHrgn(hRgn);
            DeleteObject(hRgn);
        }

        private bool EstaEmModoDesign()
        {
            return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        private string VerificarLogin()
        {
            using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
            {
                conn.Open();

                string query = @"

SELECT TipoUsuario
FROM Usuarios
WHERE Email = @Email
AND Senha = @Senha
AND (Status IS NULL OR Status <> 'Banido')";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", txtE_mail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Senha", txtSenha.Text.Trim());

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                        return resultado.ToString();

                    return null;
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            TelaDeCadastro cadastro = new TelaDeCadastro();

            this.Hide();
            cadastro.ShowDialog();
            this.Show();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtE_mail.Text) ||
                string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Preencha email e senha!");
                return;
            }

            string tipoUsuario = VerificarLogin();

            if (tipoUsuario != null)
            {
                emailDoUsuario = txtE_mail.Text;

                MessageBox.Show("Login realizado com sucesso!");

                if (tipoUsuario == "Admin")
                {
                    PainelAdmin admin = new PainelAdmin(emailDoUsuario);

                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    PaginaInformativa tela = new PaginaInformativa(emailDoUsuario);

                    this.Hide();
                    tela.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Usuário inválido ou bloqueado.");
            }
        }
    }

}
