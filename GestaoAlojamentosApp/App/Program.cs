using System;
using System.Windows.Forms;
using GestaoAlojamentosApp.App.Forms.Principal;

namespace GestaoAlojamentosApp.App
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new FormBemVindo());
        }
    }
}
