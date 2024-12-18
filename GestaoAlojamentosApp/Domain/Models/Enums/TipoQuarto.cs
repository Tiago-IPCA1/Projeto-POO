/* @file: TipoQuarto.cs
   @autor: Tiago Vale
   @data: 4 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Enum que define os diferentes tipos de quartos disponíveis.
*/

namespace GestaoAlojamentosApp.Domain.Models.Enums
{
    public enum TipoQuarto
    {
        // Quarto simples, geralmente para uma pessoa.
        Simples,

        // Quarto duplo, ideal para duas pessoas.
        Duplo,

        // Quarto triplo, ideal para três pessoas.
        Triplo,

        // Quarto suíte, geralmente de luxo.
        Suite
    }
}
