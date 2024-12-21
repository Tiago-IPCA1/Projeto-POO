using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.App.ViewModels;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.App.Controllers
{
    /// <summary>
    /// Controlador respons�vel pela gest�o de alojamentos
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class AlojamentoController
    {
        #region Atributos

        private readonly IAlojamentoService _alojamentoService;

        #endregion

        #region Construtor

        /// <summary>
        /// Inicializa o controlador de alojamento com o servi�o de alojamento fornecido.
        /// </summary>
        public AlojamentoController(IAlojamentoService alojamentoService)
        {
            _alojamentoService = alojamentoService ?? throw new ArgumentNullException(nameof(alojamentoService));
        }

        #endregion

        #region M�todos de Obten��o de Dados

        /// <summary>
        /// Obt�m todos os alojamentos registados.
        /// </summary>
        public List<AlojamentoViewModel> ObterTodosAlojamentos()
        {
            try
            {
                var alojamentos = _alojamentoService.ObterTodosAlojamentos();
                var alojamentosViewModel = new List<AlojamentoViewModel>();

                foreach (var alojamento in alojamentos)
                {
                    alojamentosViewModel.Add(AlojamentoViewModel.DeAlojamentoParaViewModel(alojamento));
                }

                return alojamentosViewModel;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao obter alojamentos: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obt�m um alojamento pelo seu ID.
        /// </summary>
        public AlojamentoViewModel? ObterAlojamentoPorId(int id)
        {
            try
            {
                var alojamento = _alojamentoService.ObterAlojamentoPorId(id);
                if (alojamento == null)
                    return null;

                return AlojamentoViewModel.DeAlojamentoParaViewModel(alojamento);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao obter alojamento por ID: {ex.Message}", ex);
            }
        }

        #endregion

        #region M�todos de Cria��o, Atualiza��o e Remo��o

        /// <summary>
        /// Cria um novo alojamento com as informa��es fornecidas.
        /// </summary>
        public bool CriarAlojamento(string nome, string localizacao, decimal precoPorNoite, int capacidade, int numeroDeQuartos, StatusAlojamento status, TipoAlojamento tipo)
        {
            try
            {
                return _alojamentoService.CriarAlojamento(nome, localizacao, precoPorNoite, capacidade, numeroDeQuartos, status, tipo);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao criar alojamento: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Atualiza as informa��es de um alojamento existente.
        /// </summary>
        public bool AtualizarAlojamento(int id, string nome, string localizacao, decimal precoPorNoite, int capacidade, int numeroDeQuartos, StatusAlojamento status, TipoAlojamento tipo)
        {
            try
            {
                return _alojamentoService.AtualizarAlojamento(id, nome, localizacao, precoPorNoite, capacidade, numeroDeQuartos, status, tipo);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao atualizar alojamento: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Remove um alojamento pelo seu ID.
        /// </summary>
        public bool RemoverAlojamento(int id)
        {
            try
            {
                return _alojamentoService.RemoverAlojamento(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao remover alojamento: {ex.Message}", ex);
            }
        }

        #endregion

        #region M�todos de Modifica��o de Status e Imagens

        /// <summary>
        /// Altera o status de um alojamento.
        /// </summary>
        public bool AlterarStatusAlojamento(int id, StatusAlojamento novoStatus)
        {
            try
            {
                var alojamento = _alojamentoService.ObterAlojamentoPorId(id);
                if (alojamento == null)
                    return false;

                return _alojamentoService.AlterarStatusAlojamento(id, novoStatus);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao alterar status do alojamento: {ex.Message}");
            }
        }

        /// <summary>
        /// Obt�m todos os alojamentos filtrados por localidade.
        /// </summary>
        public List<AlojamentoViewModel> ObterAlojamentosPorLocalizacao(string localizacao)
        {
            try
            {
                var alojamentos = _alojamentoService.ObterAlojamentosPorLocalizacao(localizacao);
                var alojamentosViewModel = new List<AlojamentoViewModel>();

                foreach (var alojamento in alojamentos)
                {
                    alojamentosViewModel.Add(AlojamentoViewModel.DeAlojamentoParaViewModel(alojamento));
                }

                return alojamentosViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter alojamentos por localiza��o: {ex.Message}");
            }
        }

        /// <summary>
        /// Adiciona uma imagem ao alojamento.
        /// </summary>
        public bool AdicionarImagemAoAlojamento(int id, string caminhoImagem)
        {
            try
            {
                return _alojamentoService.AdicionarImagem(id, caminhoImagem);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar imagem ao alojamento: {ex.Message}");
            }
        }

        /// <summary>
        /// Remove uma imagem de um alojamento.
        /// </summary>
        public bool RemoverImagemDoAlojamento(int id, string caminhoImagem)
        {
            try
            {
                return _alojamentoService.RemoverImagem(id, caminhoImagem);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao remover imagem do alojamento: {ex.Message}");
            }
        }

        #endregion
    }
}
