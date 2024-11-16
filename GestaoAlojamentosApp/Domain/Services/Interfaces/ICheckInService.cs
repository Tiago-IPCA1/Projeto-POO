/* 
   @file: ICheckInService.cs
   @autor: Tiago Vale
   @data: 14 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Interface com os métodos de serviço para CheckIn.
*/

using System;
using GestaoAlojamentosApp.Domain.Models.Entities;
using GestaoAlojamentosApp.Domain.Models.Enums;
using System.Collections.Generic;

namespace GestaoAlojamentosApp.Domain.Services.Interfaces
{
    public interface ICheckInService
    {
        CheckIn ObterPorId(int id);
        List<CheckIn> ObterCheckInsPorReserva(int reservaId);
        CheckIn CriarCheckIn(Reserva reserva, DateTime dataCheckIn, DateTime dataCheckOut);
        bool AtualizarCheckIn(CheckIn checkIn);
        bool RemoverCheckIn(int id);
        bool RealizarCheckIn(int id);
        bool AlterarStatusCheckIn(int id, StatusCheckIn novoStatus);
    }
}
