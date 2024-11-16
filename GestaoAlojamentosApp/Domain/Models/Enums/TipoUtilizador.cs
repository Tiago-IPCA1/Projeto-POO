/* @file: TipoUtilizador.cs
   @autor: Tiago Vale
   @data: 4 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descri��o: Enum que define os diferentes tipos de utilizadores do sistema.
*/

namespace GestaoAlojamentosApp.Domain.Models.Enums
{
    public enum TipoUtilizador
    {
        // Utilizador do tipo cliente, que faz reservas.
        Cliente,

        // Utilizador do tipo administrador, que � respons�vel por gerir.
        Administrador
    }
}
