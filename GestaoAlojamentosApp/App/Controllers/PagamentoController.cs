using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.App.ViewModels;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Interfaces.Services;

namespace GestaoAlojamentosApp.App.Controllers
{
    /// <summary>
    /// Controlador respons�vel pela gest�o de pagamentos
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class PagamentoController
    {
        #region Atributos

        private readonly IPagamentoService _pagamentoService;

        #endregion

        #region Construtor

        /// <summary>
        /// Inicializa o controlador de pagamentos com o servi�o de pagamento fornecido.
        /// </summary>
        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService ?? throw new ArgumentNullException(nameof(pagamentoService));
        }

        #endregion

        #region M�todos de Cria��o, Altera��o e Remo��o

        /// <summary>
        /// Cria um novo pagamento para uma reserva.
        /// </summary>
        public bool CriarPagamento(int reservaId, decimal valor, MetodoPagamento metodoPagamento, StatusPagamento status, DateTime dataPagamento)
        {
            try
            {
                // Chama o m�todo CriarPagamento no servi�o, passando os 5 par�metros corretamente
                return _pagamentoService.CriarPagamento(reservaId, valor, metodoPagamento, status, dataPagamento);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao criar pagamento: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Altera o status de um pagamento.
        /// </summary>
        public bool AlterarStatusPagamento(int id, StatusPagamento status)
        {
            try
            {
                return _pagamentoService.AlterarStatusPagamento(id, status);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao alterar status do pagamento: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Remove um pagamento pelo seu ID.
        /// </summary>
        public bool RemoverPagamento(int id)
        {
            try
            {
                return _pagamentoService.RemoverPagamentoPorId(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao remover pagamento: {ex.Message}", ex);
            }
        }

        #endregion

        #region M�todos de Obten��o de Dados

        /// <summary>
        /// Obt�m todos os pagamentos registrados.
        /// </summary>
        public List<PagamentoViewModel> ObterTodosPagamentos()
        {
            try
            {
                var pagamentos = _pagamentoService.ObterTodosPagamentos();
                var pagamentosViewModel = new List<PagamentoViewModel>();

                foreach (var pagamento in pagamentos)
                {
                    if (pagamento != null) // Garantir que o pagamento n�o seja nulo
                    {
                        pagamentosViewModel.Add(new PagamentoViewModel
                        {
                            Id = pagamento.Id,
                            ReservaId = pagamento.ReservaId,
                            Valor = pagamento.Valor,
                            MetodoPagamento = pagamento.MetodoPagamento.ToString(), 
                            StatusPagamento = pagamento.Status.ToString(), 
                            DataPagamento = pagamento.DataPagamento,
                        });
                    }
                }

                return pagamentosViewModel;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao obter todos os pagamentos: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obt�m um pagamento pelo seu ID.
        /// </summary>
        public PagamentoViewModel? ObterPagamentoPorId(int id)
        {
            try
            {
                var pagamento = _pagamentoService.ObterPagamentoPorId(id);
                if (pagamento == null) return null;

                return new PagamentoViewModel
                {
                    Id = pagamento.Id,
                    ReservaId = pagamento.ReservaId,
                    Valor = pagamento.Valor,
                    MetodoPagamento = pagamento.MetodoPagamento.ToString(),
                    StatusPagamento = pagamento.Status.ToString(),
                    DataPagamento = pagamento.DataPagamento, 
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao obter pagamento por ID: {ex.Message}", ex);
            }
        }

        #endregion
    }
}
