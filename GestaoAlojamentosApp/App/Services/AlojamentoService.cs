using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Interfaces.Services;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.App.Services
{
    /// <summary>
    /// Servi�o respons�vel pela l�gica de neg�cios relacionada � gest�o de alojamentos.
    /// Implementa funiconalidades de cria��o, atualiza��o, remo��o, consulta, de imagens e altera��o de status de alojamentos.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class AlojamentoService : IAlojamentoService
    {
        private readonly IAlojamentoRepository _alojamentoRepository;
        private readonly IAlojamentoValidator _alojamentoValidator;

        #region Construtor

        public AlojamentoService(IAlojamentoRepository alojamentoRepository, IAlojamentoValidator alojamentoValidator)
        {
            _alojamentoRepository = alojamentoRepository ?? throw new ArgumentNullException(nameof(alojamentoRepository));
            _alojamentoValidator = alojamentoValidator ?? throw new ArgumentNullException(nameof(alojamentoValidator));
        }

        #endregion

        #region M�todos de Cria��o e Atualiza��o

        public bool CriarAlojamento(string nome, string localizacao, decimal precoPorNoite, int capacidade, int numeroDeQuartos, StatusAlojamento status, TipoAlojamento tipo)
        {
            if (_alojamentoRepository.ObterAlojamentoPorNome(nome) != null)
            {
                throw new ArgumentException("Alojamento com esse nome j� existe.");
            }

            var alojamento = new Alojamento(nome, localizacao, precoPorNoite, capacidade, numeroDeQuartos, status, tipo);

            _alojamentoValidator.ValidarAlojamento(alojamento);

            _alojamentoRepository.Adicionar(alojamento);
            return true;
        }

        public bool AtualizarAlojamento(int id, string nome, string localizacao, decimal precoPorNoite, int capacidade, int numeroDeQuartos, StatusAlojamento status, TipoAlojamento tipo)
        {
            var alojamento = _alojamentoRepository.ObterPorId(id);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {id} n�o encontrado.");

            alojamento.Nome = nome;
            alojamento.Localizacao = localizacao;
            alojamento.PrecoPorNoite = precoPorNoite;
            alojamento.Capacidade = capacidade;
            alojamento.NumeroDeQuartos = numeroDeQuartos;
            alojamento.Status = status;
            alojamento.Tipo = tipo;

            _alojamentoValidator.ValidarAlojamento(alojamento);

            _alojamentoRepository.Atualizar(alojamento);
            return true;
        }

        #endregion

        #region M�todos de Remo��o

        public bool RemoverAlojamento(int id)
        {
            var alojamento = _alojamentoRepository.ObterPorId(id);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {id} n�o encontrado.");

            _alojamentoRepository.Remover(id);
            return true;
        }

        #endregion

        #region M�todos de Consultas

        public List<Alojamento> ObterTodosAlojamentos() => _alojamentoRepository.ObterTodos();

        public Alojamento? ObterAlojamentoPorId(int id)
        {
            var alojamento = _alojamentoRepository.ObterPorId(id);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {id} n�o encontrado.");
            return alojamento;
        }

        public Alojamento? ObterAlojamentoPorNome(string nome)
        {
            var alojamento = _alojamentoRepository.ObterAlojamentoPorNome(nome);  
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com nome {nome} n�o encontrado.");
            return alojamento;
        }

        public List<Alojamento> ObterAlojamentosPorLocalizacao(string localizacao)
        {
            return _alojamentoRepository.ObterAlojamentosPorLocalizacao(localizacao);
        }

        public List<Alojamento> AlojamentosDisponiveis(DateTime dataInicio, DateTime dataFim, int capacidade)
        {
            if (dataFim <= dataInicio)
                throw new ArgumentException("A data de t�rmino n�o pode ser anterior ou igual � data de in�cio.");
            return _alojamentoRepository.ObterAlojamentosDisponiveis(dataInicio, dataFim, capacidade);
        }

        #endregion

        #region M�todos de Imagens

        public bool AdicionarImagem(int idAlojamento, string caminhoImagem)
        {
            var alojamento = _alojamentoRepository.ObterPorId(idAlojamento);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {idAlojamento} n�o encontrado.");

            alojamento.Imagens.Add(caminhoImagem);
            _alojamentoRepository.Atualizar(alojamento);
            return true;
        }

        public bool RemoverImagem(int idAlojamento, string caminhoImagem)
        {
            var alojamento = _alojamentoRepository.ObterPorId(idAlojamento);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {idAlojamento} n�o encontrado.");

            if (!alojamento.Imagens.Contains(caminhoImagem))
                throw new ArgumentException("Imagem n�o encontrada.");

            alojamento.Imagens.Remove(caminhoImagem);
            _alojamentoRepository.Atualizar(alojamento);
            return true;
        }

        #endregion

        #region M�todos de Altera��o de Status

        public bool AlterarStatusAlojamento(int id, StatusAlojamento status)
        {
            var alojamento = _alojamentoRepository.ObterPorId(id);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {id} n�o encontrado.");

            alojamento.Status = status;
            _alojamentoRepository.Atualizar(alojamento);
            return true;
        }

        #endregion

    }
}
