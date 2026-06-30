using System;
using System.Windows.Forms;
using Proyecto1.Forms;

namespace Proyecto1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FrmInicio());
        }
    }
}