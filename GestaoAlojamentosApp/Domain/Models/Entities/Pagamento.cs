/* @file: Pagamento.cs
   @autor: Tiago Vale
   @data: 5 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Classe que representa o pagamento de uma reserva.
*/

using System;
using GestaoAlojamentosApp.Domain.Models.Enums;
using GestaoAlojamentosApp.Utils.CriarIds;

namespace GestaoAlojamentosApp.Domain.Models.Entities
{
    public class Pagamento
    {
        #region Propriedades

        // Propriedades
        public int Id { get; private set; }
        public Reserva Reserva { get; private set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public StatusPagamento Status { get; private set; }

        #endregion

        #region Construtor

        // Construtor 
        public Pagamento(Reserva reserva, decimal valor)
        {
            Id = CriarIds.CriarNovoId();
            Reserva = reserva;
            Status = StatusPagamento.Pendente; // Inicializa com status "Pendente"
            Valor = valor;
            DataPagamento = DateTime.Now; // Data de pagamento no momento da criação
        }

        #endregion
    }
}
