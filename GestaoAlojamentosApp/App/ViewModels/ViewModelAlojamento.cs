using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.App.ViewModels
{
    /// <summary>
    /// Classe responsável por representar o modelo de dados de um alojamento.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class AlojamentoViewModel
    {
        #region Propriedades

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
        public decimal PrecoPorNoite { get; set; }
        public int Capacidade { get; set; }
        public StatusAlojamento Status { get; set; }
        public TipoAlojamento Tipo { get; set; }
        public int NumeroDeQuartos { get; set; }
        public List<string> Imagens { get; set; } = new List<string>();

        #endregion

        #region Métodos de Conversão

        // Método que converte de Alojamento para AlojamentoViewModel
        public static AlojamentoViewModel DeAlojamentoParaViewModel(Alojamento alojamento)
        {
            if (alojamento == null)
                throw new ArgumentNullException(nameof(alojamento), "Alojamento não pode ser nulo.");

            return new AlojamentoViewModel
            {
                Id = alojamento.Id,
                Nome = alojamento.Nome ?? string.Empty,
                Localizacao = alojamento.Localizacao ?? string.Empty,
                PrecoPorNoite = alojamento.PrecoPorNoite,
                Capacidade = alojamento.Capacidade,
                Status = alojamento.Status,
                Tipo = alojamento.Tipo,
                NumeroDeQuartos = alojamento.NumeroDeQuartos,
                Imagens = alojamento.Imagens ?? new List<string>()
            };
        }

        // Método que converte de AlojamentoViewModel para Alojamento
        public Alojamento ParaAlojamento()
        {
            if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(Localizacao))
                throw new ArgumentException("Nome e Localização não podem ser nulos ou vazios.");

            return new Alojamento(
                Nome,
                Localizacao,
                PrecoPorNoite,
                Capacidade,
                NumeroDeQuartos,
                Status,
                Tipo
            );
        }

        #endregion
    }
}
