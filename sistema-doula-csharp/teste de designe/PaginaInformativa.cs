using System;
using System.Windows.Forms;

namespace teste_de_designe
{
    public partial class PaginaInformativa : Form
    {
        private string emailDoUsuario;
        private System.Windows.Forms.Timer timerNotificacao;
        private NotificacaoService notificacaoService;
        private EmailService emailService;

        public PaginaInformativa(string email)
        {
            InitializeComponent();
            emailDoUsuario = email;

            this.Load += PaginaInformativa_Load;
            this.FormClosing += PaginaInformativa_FormClosing;
        }

        private void PaginaInformativa_Load(object sender, EventArgs e)
        {
            try
            {
                emailService = new EmailService(
                    "smtp.gmail.com",
                    587,
                    "projetodoulaefuro01@gmail.com",
                    "qvxmylkwzrgqtiee",
                    "Sistema Doula"
                );

                notificacaoService = new NotificacaoService(emailService);

                timerNotificacao = new System.Windows.Forms.Timer();
                timerNotificacao.Interval = 60000; // 1 minuto
                timerNotificacao.Tick += TimerNotificacao_Tick;
                timerNotificacao.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar serviço de e-mail:\n" + ex.Message);
            }
        }

        private void TimerNotificacao_Tick(object sender, EventArgs e)
        {
            try
            {
                notificacaoService.ProcessarNotificacoes24h();
                notificacaoService.ProcessarNotificacoes1h();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar notificações:\n" + ex.Message);
            }
        }

        private void btnPaginaInformativa_Agendar_Click(object sender, EventArgs e)
        {
            PaginaAgendamentoDoula tela = new PaginaAgendamentoDoula(emailDoUsuario);

            this.Hide();
            tela.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaginaInformativa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerNotificacao != null)
            {
                timerNotificacao.Stop();
                timerNotificacao.Dispose();
            }
        }
    }
}