/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Classe que representa um devido alojamento
*/
using System;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Utils;

namespace GestaoAlojamentosApp.Domain.Models
{
    public class Alojamento
    {
        #region Propriedades

        // Propriedades
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public TipoQuarto TipoQuarto { get; set; }
        public int Capacidade { get; set; }
        public int NumeroQuartos { get; set; }
        public decimal Preco { get; set; }
        public StatusAlojamento Status { get; private set; }

        #endregion

        #region Construtores

        // Construtor 
        public Alojamento(string nome, string localizacao, TipoQuarto tipoQuarto, int capacidade, int numeroQuartos, decimal preco)
        {
            Id = CriarIds.CriarNovoId();
            Nome = nome;
            Localizacao = localizacao;
            TipoQuarto = tipoQuarto;
            Capacidade = capacidade;
            NumeroQuartos = numeroQuartos;
            Preco = preco;
            Status = StatusAlojamento.Disponivel; // Inicializa o Status como "Disponível"
        }

        #endregion
    }
}
