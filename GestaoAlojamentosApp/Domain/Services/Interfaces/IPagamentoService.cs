/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descri��o: Interface com os m�todos de servi�o para Pagamento.
*/

using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Services
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
