/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Classe que representa o pagamento de uma reserva.
*/
using System;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Utils;

namespace GestaoAlojamentosApp.Domain.Models
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
