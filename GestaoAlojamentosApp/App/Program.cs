using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using GestaoAlojamentosApp.App.Forms;

namespace GestaoAlojamentosApp.App
{
    /// <summary>
    /// Classe principal da aplica��o, respons�vel por inicializar a interface gr�fica.
    /// O sistema � iniciada com a configura��o do cont�iner de servi�os e a exibi��o do formul�rio principal.
    /// Caso ocorra algum erro durante o processo de inicializa��o, uma mensagem de erro � exibida.
    /// 
    /// Acesso ao sistema:
    /// - Admin: O usu�rio administrador pode aceder ao sistema com as credenciais:
    ///   - Usu�rio: admin
    ///   - Senha: admin123
    /// 
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                var serviceProvider = DIConfig.ConfigureServices();
                var formPrincipal = serviceProvider.GetRequiredService<FormPrincipal>();

                Application.Run(formPrincipal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar a aplica��o: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
