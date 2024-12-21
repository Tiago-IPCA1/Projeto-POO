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
    /// Classe respons�vel pela configura��o e registo dos servi�os e depend�ncias do sistema usa Inje��o de Depend�ncia.
    /// Regista validadores, reposit�rios, servi�os, controladores e formul�rios necess�rios para o funcionamento da aplica��o.
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

            // Registar os Reposit�rios
            serviceCollection.AddScoped<ICheckInRepository, CheckInRepository>();
            serviceCollection.AddScoped<IAlojamentoRepository, AlojamentoRepository>();
            serviceCollection.AddScoped<IClienteRepository, ClienteRepository>();
            serviceCollection.AddScoped<IReservaRepository, ReservaRepository>();
            serviceCollection.AddScoped<IPagamentoRepository, PagamentoRepository>();
            serviceCollection.AddScoped<IUtilizadorRepository, UtilizadorRepository>();

            // Registar os Servi�os
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

            // Registar os Formul�rios
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
