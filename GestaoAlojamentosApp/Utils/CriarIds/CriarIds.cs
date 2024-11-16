/* 
   @file: CriarIds.cs
   @autor: Tiago Vale
   @data: 15 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descri��o: Classe respons�vel por criar IDs �nicos e sequenciais.
*/

using System;

namespace GestaoAlojamentosApp.Utils.CriarIds
{
	/// <summary>
	/// Classe para criar IDs �nicos sequenciais.
	/// </summary>
	public static class CriarIds
	{
		private static int _contadorDeIds = 1;

		/// <summary>
		/// Cria um novo ID �nico e sequencial.
		/// </summary>
		/// <returns>Um n�mero inteiro que ir� representar o novo ID.</returns>
		public static int CriarNovoId()
		{
			return _contadorDeIds++;
		}
	}
}
