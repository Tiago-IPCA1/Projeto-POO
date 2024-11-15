/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Interface com os métodos de serviço para Reservas.
*/

using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Services
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
