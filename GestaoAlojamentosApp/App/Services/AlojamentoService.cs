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
    /// Serviço responsável pela lógica de negócios relacionada à gestão de alojamentos.
    /// Implementa funiconalidades de criação, atualização, remoção, consulta, de imagens e alteração de status de alojamentos.
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

        #region Métodos de Criação e Atualização

        public bool CriarAlojamento(string nome, string localizacao, decimal precoPorNoite, int capacidade, int numeroDeQuartos, StatusAlojamento status, TipoAlojamento tipo)
        {
            if (_alojamentoRepository.ObterAlojamentoPorNome(nome) != null)
            {
                throw new ArgumentException("Alojamento com esse nome já existe.");
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
                throw new KeyNotFoundException($"Alojamento com ID {id} não encontrado.");

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

        #region Métodos de Remoção

        public bool RemoverAlojamento(int id)
        {
            var alojamento = _alojamentoRepository.ObterPorId(id);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {id} não encontrado.");

            _alojamentoRepository.Remover(id);
            return true;
        }

        #endregion

        #region Métodos de Consultas

        public List<Alojamento> ObterTodosAlojamentos() => _alojamentoRepository.ObterTodos();

        public Alojamento? ObterAlojamentoPorId(int id)
        {
            var alojamento = _alojamentoRepository.ObterPorId(id);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {id} não encontrado.");
            return alojamento;
        }

        public Alojamento? ObterAlojamentoPorNome(string nome)
        {
            var alojamento = _alojamentoRepository.ObterAlojamentoPorNome(nome);  
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com nome {nome} não encontrado.");
            return alojamento;
        }

        public List<Alojamento> ObterAlojamentosPorLocalizacao(string localizacao)
        {
            return _alojamentoRepository.ObterAlojamentosPorLocalizacao(localizacao);
        }

        public List<Alojamento> AlojamentosDisponiveis(DateTime dataInicio, DateTime dataFim, int capacidade)
        {
            if (dataFim <= dataInicio)
                throw new ArgumentException("A data de término não pode ser anterior ou igual à data de início.");
            return _alojamentoRepository.ObterAlojamentosDisponiveis(dataInicio, dataFim, capacidade);
        }

        #endregion

        #region Métodos de Imagens

        public bool AdicionarImagem(int idAlojamento, string caminhoImagem)
        {
            var alojamento = _alojamentoRepository.ObterPorId(idAlojamento);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {idAlojamento} não encontrado.");

            alojamento.Imagens.Add(caminhoImagem);
            _alojamentoRepository.Atualizar(alojamento);
            return true;
        }

        public bool RemoverImagem(int idAlojamento, string caminhoImagem)
        {
            var alojamento = _alojamentoRepository.ObterPorId(idAlojamento);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {idAlojamento} não encontrado.");

            if (!alojamento.Imagens.Contains(caminhoImagem))
                throw new ArgumentException("Imagem não encontrada.");

            alojamento.Imagens.Remove(caminhoImagem);
            _alojamentoRepository.Atualizar(alojamento);
            return true;
        }

        #endregion

        #region Métodos de Alteração de Status

        public bool AlterarStatusAlojamento(int id, StatusAlojamento status)
        {
            var alojamento = _alojamentoRepository.ObterPorId(id);
            if (alojamento == null)
                throw new KeyNotFoundException($"Alojamento com ID {id} não encontrado.");

            alojamento.Status = status;
            _alojamentoRepository.Atualizar(alojamento);
            return true;
        }

        #endregion

    }
}
