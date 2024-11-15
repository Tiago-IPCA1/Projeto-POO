/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descri��o: Classe respons�vel por criar IDs �nicos e sequenciais.
*/

namespace GestaoAlojamentosApp.Domain.Utils
{
    public static class CriarIds
    {
        private static int _contadorDeIds = 1;

        // M�todo para criar um novo ID �nico
        public static int CriarNovoId()
        {
            return _contadorDeIds++;
        }
    }
}
