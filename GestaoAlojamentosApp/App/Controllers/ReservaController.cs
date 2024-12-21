using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.App.ViewModels;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.App.Controllers
{
    /// <summary>
    /// Controlador respons�vel pela gest�o de reservas.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ReservaController
    {
        #region Atributos

        private readonly IReservaService _reservaService;
        private readonly IClienteService _clienteService; // Depend�ncia do servi�o de cliente
        private readonly IAlojamentoService _alojamentoService; // Depend�ncia do servi�o de alojamento

        #endregion

        #region Construtor

        /// <summary>
        /// Inicializa o controlador de reservas com os servi�os fornecidos.
        /// </summary>
        public ReservaController(IReservaService reservaService, IClienteService clienteService, IAlojamentoService alojamentoService)
        {
            _reservaService = reservaService ?? throw new ArgumentNullException(nameof(reservaService));
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
            _alojamentoService = alojamentoService ?? throw new ArgumentNullException(nameof(alojamentoService));
        }

        #endregion

        #region M�todos de Obten��o de Dados

        /// <summary>
        /// Obt�m todas as reservas registradas.
        /// </summary>
        public List<ReservaViewModel> ObterTodasReservas()
        {
            try
            {
                var reservas = _reservaService.ObterTodasReservas();
                var reservaViewModels = new List<ReservaViewModel>();

                foreach (var reserva in reservas)
                {
                    try
                    {
                        var alojamento = _alojamentoService.ObterAlojamentoPorId(reserva.AlojamentoId);

                        // Verifica se o alojamento foi removido ou n�o encontrado
                        if (alojamento == null)
                        {
                            // Alojamento removido, ignora a reserva
                            continue;
                        }

                        var viewModel = ReservaViewModel.DeReservaParaViewModel(reserva, _clienteService, _alojamentoService);
                        if (viewModel != null)
                        {
                            reservaViewModels.Add(viewModel);
                        }
                    }
                    catch
                    {
                        // Se ocorrer qualquer erro ao processar a reserva, ignora a reserva e continua o fluxo
                        continue;
                    }
                }

                return reservaViewModels;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao obter todas as reservas: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obt�m uma reserva pelo seu ID.
        /// </summary>
        public ReservaViewModel? ObterReservaPorId(int id)
        {
            try
            {
                var reserva = _reservaService.ObterReservaPorId(id);
                if (reserva == null)
                    return null;

                // Verifica se o alojamento ainda existe
                var alojamento = _alojamentoService.ObterAlojamentoPorId(reserva.AlojamentoId);
                if (alojamento == null)
                {
                    // Se o alojamento foi removido, ignora a reserva
                    return null;
                }

                return ReservaViewModel.DeReservaParaViewModel(reserva, _clienteService, _alojamentoService);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao obter reserva por ID: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obt�m as reservas filtradas por status.
        /// </summary>
        public List<ReservaViewModel> ObterReservasPorStatus(StatusReserva status)
        {
            try
            {
                var reservas = _reservaService.ObterReservasPorStatus(status);
                var reservaViewModels = new List<ReservaViewModel>();

                foreach (var reserva in reservas)
                {
                    try
                    {
                        var alojamento = _alojamentoService.ObterAlojamentoPorId(reserva.AlojamentoId);

                        // Verifica se o alojamento foi removido ou n�o encontrado
                        if (alojamento == null)
                        {
                            // Alojamento removido, ignora a reserva
                            continue;
                        }

                        var viewModel = ReservaViewModel.DeReservaParaViewModel(reserva, _clienteService, _alojamentoService);
                        if (viewModel != null)
                        {
                            reservaViewModels.Add(viewModel);
                        }
                    }
                    catch
                    {
                        // Se ocorrer qualquer erro ao processar a reserva, ignora a reserva e continua o fluxo
                        continue;
                    }
                }

                return reservaViewModels;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao obter reservas por status: {ex.Message}", ex);
            }
        }

        #endregion

        #region M�todos de Cria��o, Atualiza��o e Remo��o

        /// <summary>
        /// Cria uma nova reserva com as informa��es fornecidas.
        /// </summary>
        public bool CriarReserva(string clienteEmail, string alojamentoNome, DateTime dataInicio, DateTime dataFim, int numeroDePessoas)
        {
            try
            {
                // Obt�m cliente e alojamento por email e nome
                var clientes = _clienteService.ObterClientesPorEmail(clienteEmail);
                var alojamento = _alojamentoService.ObterAlojamentoPorNome(alojamentoNome);

                // Verifica se o cliente e o alojamento existem
                if (alojamento == null || clientes == null || clientes.Count == 0)
                {
                    throw new ArgumentException("Cliente ou Alojamento n�o encontrado.");
                }

                // Pegando o primeiro cliente da lista, caso haja m�ltiplos clientes com o mesmo email
                var cliente = clientes[0];

                // Calcula o n�mero de noites
                int numeroNoites = (dataFim - dataInicio).Days;

                // Calcula o pre�o total
                decimal precoTotal = numeroNoites * alojamento.PrecoPorNoite;

                // Chama o servi�o para criar a reserva, passa o pre�o calculado
                return _reservaService.CriarReserva(cliente.Id, alojamento.Id, dataInicio, dataFim, precoTotal, numeroDePessoas);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao criar reserva: {ex.Message}", ex);
            }
        }


        /// <summary>
        /// Atualiza as informa��es de uma reserva existente.
        /// </summary>
        public bool AtualizarReserva(int id, string clienteEmail, string alojamentoNome, DateTime dataInicio, DateTime dataFim, int numeroDePessoas)
        {
            try
            {
                // Acessa o cliente e alojamento para obter os IDs necess�rios
                var clientes = _clienteService.ObterClientesPorEmail(clienteEmail);
                if (clientes == null || clientes.Count == 0)
                {
                    throw new ArgumentException("Cliente n�o encontrado com o email fornecido.");
                }
                var cliente = clientes[0];

                var alojamento = _alojamentoService.ObterAlojamentoPorNome(alojamentoNome);
                if (alojamento == null)
                {
                    throw new ArgumentException("Alojamento n�o encontrado com o nome fornecido.");
                }

                // Obt�m o pre�o total para o alojamento
                decimal precoTotal = alojamento.PrecoPorNoite * (dataFim - dataInicio).Days;

                // Chama o servi�o para atualizar a reserva
                return _reservaService.AtualizarReserva(id, cliente.Id, alojamento.Id, dataInicio, dataFim, precoTotal, numeroDePessoas);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao atualizar reserva: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Remove uma reserva pelo seu ID.
        /// </summary>
        public bool RemoverReserva(int id)
        {
            try
            {
                return _reservaService.RemoverReserva(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao remover reserva: {ex.Message}", ex);
            }
        }

        #endregion

        #region M�todos de Altera��o de Status

        /// <summary>
        /// Altera o status de uma reserva.
        /// </summary>
        public bool AlterarStatusReserva(int reservaId, StatusReserva novoStatus)
        {
            try
            {
                return _reservaService.AlterarStatusReserva(reservaId, novoStatus);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao alterar status da reserva: {ex.Message}", ex);
            }
        }

        #endregion
    }
}
