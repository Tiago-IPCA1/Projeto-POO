/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Interface com os métodos de serviço para CheckIn.
*/

using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Services
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
