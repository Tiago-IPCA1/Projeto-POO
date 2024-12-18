/* @file: StatusPagamento.cs
   @autor: Tiago Vale
   @data: 4 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Enum que define os diferentes status de um Pagamento.
*/

namespace GestaoAlojamentosApp.Domain.Models.Enums
{
    public enum StatusPagamento
    {
        // Pagamento ainda não foi realizado.
        Pendente,

        // Pagamento foi confirmado.
        Confirmado,

        // Pagamento foi cancelado.
        Cancelado
    }
}
