/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Classe responsável por criar IDs únicos e sequenciais.
*/

namespace GestaoAlojamentosApp.Domain.Utils
{
    public static class CriarIds
    {
        private static int _contadorDeIds = 1;

        // Método para criar um novo ID único
        public static int CriarNovoId()
        {
            return _contadorDeIds++;
        }
    }
}
