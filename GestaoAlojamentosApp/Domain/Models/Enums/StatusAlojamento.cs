/* @file: StatusAlojamento.cs
   @autor: Tiago Vale
   @data: 5 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descri��o: Classe que representa o enum StatusAlojamento, que define os estados de um alojamento.
*/

namespace GestaoAlojamentosApp.Domain.Models.Enums
{
    public enum StatusAlojamento
    {
        // Alojamento est� dispon�vel para uma dada reserva.
        Disponivel,

        // Alojamento est� indispon�vel para uma dada reserva.
        Indisponivel,

        // Alojamento est� em manuten��o, por tempo indefinido, e n�o pode ser reservado.
        EmManutencao
    }
}
