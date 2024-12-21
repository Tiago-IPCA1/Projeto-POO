using System;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Validators;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;

namespace GestaoAlojamentosApp.Domain.Validators
{
    /// <summary>
    /// Classe respons�vel pela valida��o dos dados de alojamento.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class AlojamentoValidator : IAlojamentoValidator
    {
        private readonly IAlojamentoRepository _alojamentoRepository;

        #region Construtor

        public AlojamentoValidator(IAlojamentoRepository alojamentoRepository)
        {
            _alojamentoRepository = alojamentoRepository ?? throw new ArgumentNullException(nameof(alojamentoRepository));
        }

        #endregion

        #region M�todos de Valida��o

        public bool ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do alojamento n�o pode ser nulo ou vazio.", nameof(nome));
            return true;
        }

        public bool ValidarLocalizacao(string localizacao)
        {
            if (string.IsNullOrWhiteSpace(localizacao))
                throw new ArgumentException("A localiza��o do alojamento n�o pode ser nula ou vazia.", nameof(localizacao));
            return true;
        }

        public bool ValidarPrecoPorNoite(decimal precoPorNoite)
        {
            if (precoPorNoite <= 0)
                throw new ArgumentException("O pre�o por noite deve ser maior que zero.", nameof(precoPorNoite));
            return true;
        }

        public bool ValidarCapacidade(int capacidade)
        {
            if (capacidade <= 0)
                throw new ArgumentException("A capacidade deve ser maior que zero.", nameof(capacidade));
            return true;
        }

        public bool ValidarAlojamentoDuplicado(string nome, string localizacao, int idAlojamentoExcluir = 0)
        {
            var alojamentoExistente = _alojamentoRepository.ObterAlojamentoPorNomeELocalizacao(nome, localizacao);
            if (alojamentoExistente != null && alojamentoExistente.Id != idAlojamentoExcluir)
            {
                throw new ArgumentException("J� existe um alojamento com o mesmo nome e localiza��o.", nameof(nome));
            }
            return true;
        }

        public bool ValidarAlojamento(Alojamento alojamento)
        {
            // Valida todas as propriedades do alojamento
            ValidarNome(alojamento.Nome);
            ValidarLocalizacao(alojamento.Localizacao);
            ValidarPrecoPorNoite(alojamento.PrecoPorNoite);
            ValidarCapacidade(alojamento.Capacidade);
            ValidarAlojamentoDuplicado(alojamento.Nome, alojamento.Localizacao, alojamento.Id);
            return true;
        }

        #endregion
    }
}