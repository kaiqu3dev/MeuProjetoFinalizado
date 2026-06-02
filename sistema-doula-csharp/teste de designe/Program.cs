using System;
using System.Windows.Forms;

namespace teste_de_designe
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                Application.Run(new PaginaLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Erro ao iniciar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}