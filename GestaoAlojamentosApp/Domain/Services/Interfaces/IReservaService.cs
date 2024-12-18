/* 
   @file: IReservaService.cs
   @autor: Tiago Vale
   @data: 14 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Interface com os métodos de serviço para Reservas.
*/

using System;
using GestaoAlojamentosApp.Domain.Models.Entities;
using GestaoAlojamentosApp.Domain.Models.Enums;
using System.Collections.Generic;

namespace GestaoAlojamentosApp.Domain.Services.Interfaces
{
    public interface IReservaService
    {
        Reserva ObterPorId(int id);
        List<Reserva> ObterReservasPorCliente(int clienteId);
        List<Reserva> ObterReservasPorAlojamento(int alojamentoId);
        Reserva CriarReserva(Alojamento alojamento, Cliente cliente, DateTime dataReserva, DateTime dataCheckIn, DateTime dataCheckOut);
        bool AtualizarReserva(Reserva reserva);
        bool RemoverReserva(int id);
        bool AlterarStatusReserva(int id, StatusReserva novoStatus);
        decimal CalcularPrecoReserva(int id, int numeroDeNoites);
    }
}
