using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Utils.CriarIds;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Models
{
    /// <summary>
    /// Classe que representa um alojamento, contendo informações como nome, localização,
    /// preço por noite, capacidade, número de quartos, status, tipo, imagens e período de disponibilidade.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class Alojamento
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public decimal PrecoPorNoite { get; set; }
        public int Capacidade { get; set; }
        public int NumeroDeQuartos { get; set; }
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public StatusAlojamento Status { get; set; }
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TipoAlojamento Tipo { get; set; }
        public List<string> Imagens { get; set; } = new List<string>();

        /// <summary>
        /// Construtor da classe Alojamento.
        /// </summary>
        /// <param name="nome">Nome do alojamento.</param>
        /// <param name="localizacao">Localização do alojamento.</param>
        /// <param name="precoPorNoite">Preço por noite.</param>
        /// <param name="capacidade">Capacidade máxima.</param>
        /// <param name="numeroDeQuartos">Número de quartos.</param>
        /// <param name="status">Status do alojamento.</param>
        /// <param name="tipo">Tipo de alojamento.</param>
        public Alojamento(string nome, string localizacao, decimal precoPorNoite, int capacidade, int numeroDeQuartos, StatusAlojamento status, TipoAlojamento tipo)
        {
            Id = GeradorId.GerarIdAlojamento();
            Nome = nome;
            Localizacao = localizacao;
            PrecoPorNoite = precoPorNoite;
            Capacidade = capacidade;
            NumeroDeQuartos = numeroDeQuartos;
            Status = status;
            Tipo = tipo;
        }
    }
}
