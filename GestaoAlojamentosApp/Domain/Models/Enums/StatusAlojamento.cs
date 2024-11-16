/* @file: StatusAlojamento.cs
   @autor: Tiago Vale
   @data: 5 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Classe que representa o enum StatusAlojamento, que define os estados de um alojamento.
*/

namespace GestaoAlojamentosApp.Domain.Models.Enums
{
    public enum StatusAlojamento
    {
        // Alojamento está disponível para uma dada reserva.
        Disponivel,

        // Alojamento está indisponível para uma dada reserva.
        Indisponivel,

        // Alojamento está em manutenção, por tempo indefinido, e não pode ser reservado.
        EmManutencao
    }
}
