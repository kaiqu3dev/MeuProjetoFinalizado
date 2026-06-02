using System;
using System.Diagnostics;

namespace teste_de_designe
{
    public class WhatsAppService
    {
        public void AbrirWhatsApp(string telefone, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return;

            string numero = SomenteNumeros(telefone);

            if (!numero.StartsWith("55"))
                numero = "55" + numero;

            string texto = Uri.EscapeDataString(mensagem);
            string url = $"https://wa.me/{numero}?text={texto}";

            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private string SomenteNumeros(string texto)
        {
            string resultado = "";

            foreach (char c in texto)
            {
                if (char.IsDigit(c))
                    resultado += c;
            }

            return resultado;
        }
    }
}