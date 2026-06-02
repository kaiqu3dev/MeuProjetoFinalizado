using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace teste_de_designe
{
    public class EmailService
    {
        private readonly string smtpServer;
        private readonly int smtpPort;
        private readonly string emailRemetente;
        private readonly string senhaApp;
        private readonly string nomeRemetente;

        public EmailService(string smtpServer, int smtpPort, string emailRemetente, string senhaApp, string nomeRemetente)
        {
            this.smtpServer = smtpServer;
            this.smtpPort = smtpPort;
            this.emailRemetente = emailRemetente;
            this.senhaApp = senhaApp;
            this.nomeRemetente = nomeRemetente;
        }

        public void EnviarEmail(string destino, string assunto, string corpo)
        {
            var mensagem = new MimeMessage();

            mensagem.From.Add(new MailboxAddress(nomeRemetente, emailRemetente));
            mensagem.To.Add(MailboxAddress.Parse(destino));
            mensagem.Subject = assunto;
            mensagem.Body = new TextPart("plain")
            {
                Text = corpo
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(smtpServer, smtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(emailRemetente, senhaApp);
                smtp.Send(mensagem);
                smtp.Disconnect(true);
            }
        }
    }
}