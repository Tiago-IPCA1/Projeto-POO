using Microsoft.Extensions.DependencyInjection;
using GestaoAlojamentosApp.App.Controllers;
using GestaoAlojamentosApp.App.Services;
using GestaoAlojamentosApp.Infrastructure.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.App.Forms;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.Domain.Validators;

namespace GestaoAlojamentosApp.App
{
    /// <summary>
    /// Classe responsável pela configuração e registo dos serviços e dependências do sistema usa Injeção de Dependência.
    /// Regista validadores, repositórios, serviços, controladores e formulários necessários para o funcionamento da aplicação.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    public static class DIConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<ICheckInValidator, CheckInValidator>();
            serviceCollection.AddScoped<IAlojamentoValidator, AlojamentoValidator>(); 
            serviceCollection.AddScoped<IClienteValidator, ClienteValidator>(); 
            serviceCollection.AddScoped<IReservaValidator, ReservaValidator>(); 
            serviceCollection.AddScoped<IPagamentoValidator, PagamentoValidator>();

            // Registar os Repositórios
            serviceCollection.AddScoped<ICheckInRepository, CheckInRepository>();
            serviceCollection.AddScoped<IAlojamentoRepository, AlojamentoRepository>();
            serviceCollection.AddScoped<IClienteRepository, ClienteRepository>();
            serviceCollection.AddScoped<IReservaRepository, ReservaRepository>();
            serviceCollection.AddScoped<IPagamentoRepository, PagamentoRepository>();
            serviceCollection.AddScoped<IUtilizadorRepository, UtilizadorRepository>();

            // Registar os Serviços
            serviceCollection.AddScoped<IUtilizadorService, UtilizadorService>();
            serviceCollection.AddScoped<IAlojamentoService, AlojamentoService>();
            serviceCollection.AddScoped<IClienteService, ClienteService>();
            serviceCollection.AddScoped<IReservaService, ReservaService>();
            serviceCollection.AddScoped<ICheckInService, CheckInService>();
            serviceCollection.AddScoped<IPagamentoService, PagamentoService>();

            // Registar os Controladores
            serviceCollection.AddScoped<UtilizadorController>();
            serviceCollection.AddScoped<AlojamentoController>();
            serviceCollection.AddScoped<ClienteController>();
            serviceCollection.AddScoped<ReservaController>();
            serviceCollection.AddScoped<CheckInController>();
            serviceCollection.AddScoped<PagamentoController>();

            // Registar os Formulários
            serviceCollection.AddScoped<FormPrincipal>();
            serviceCollection.AddScoped<FormMenuAdministrador>();
            serviceCollection.AddScoped<FormGestaoAlojamentos>();
            serviceCollection.AddScoped<FormGestaoClientes>();
            serviceCollection.AddScoped<FormGestaoReservas>();
            serviceCollection.AddScoped<FormGestaoCheckIns>();
            serviceCollection.AddScoped<FormGestaoPagamentos>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
