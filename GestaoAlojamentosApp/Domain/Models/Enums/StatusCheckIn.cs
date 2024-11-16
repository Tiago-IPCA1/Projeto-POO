/* @file: StatusCheckIn.cs
   @autor: Tiago Vale
   @data: 4 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descri��o: Enum que define os diferentes status de um Check-in.
*/

namespace GestaoAlojamentosApp.Domain.Models.Enums
{
    public enum StatusCheckIn
    {
        // Check-in ainda n�o foi realizado.
        Pendente,

        // Check-in foi confirmado.
        Confirmado,

        // Check-in foi cancelado.
        Cancelado
    }
}
