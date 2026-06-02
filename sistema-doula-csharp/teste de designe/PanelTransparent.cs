using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace teste_de_designe
{
    public class PanelTransparente : Panel
    {
        public PanelTransparente()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.SupportsTransparentBackColor, true);

            DoubleBuffered = true;
            BackColor = Color.FromArgb(80, 180, 230, 200);
        }
    }
}