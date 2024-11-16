/* 
   @file: IPagamentoService.cs
   @autor: Tiago Vale
   @data: 14 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Interface com os métodos de serviço para Pagamento.
*/

using System;
using GestaoAlojamentosApp.Domain.Models.Entities;
using GestaoAlojamentosApp.Domain.Models.Enums;
using System.Collections.Generic;

namespace GestaoAlojamentosApp.Domain.Services.Interfaces
{
    public interface IPagamentoService
    {
        Pagamento ObterPorId(int id);
        List<Pagamento> ObterPagamentosPorReserva(int reservaId);
        Pagamento CriarPagamento(Reserva reserva, decimal valor);
        bool RealizarPagamento(int id);
        bool VerificarStatusPagamento(int reservaId);
    }
}
