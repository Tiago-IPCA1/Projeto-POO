using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using GestaoAlojamentosApp.App.Forms;

namespace GestaoAlojamentosApp.App
{
    /// <summary>
    /// Classe principal da aplicação, responsável por inicializar a interface gráfica.
    /// O sistema é iniciada com a configuração do contêiner de serviços e a exibição do formulário principal.
    /// Caso ocorra algum erro durante o processo de inicialização, uma mensagem de erro é exibida.
    /// 
    /// Acesso ao sistema:
    /// - Admin: O usuário administrador pode aceder ao sistema com as credenciais:
    ///   - Usuário: admin
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
                MessageBox.Show($"Erro ao iniciar a aplicação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
