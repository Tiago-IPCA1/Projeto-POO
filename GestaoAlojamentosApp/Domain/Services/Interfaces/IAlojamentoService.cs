/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descri��o: Interface com os m�todos de servi�o para Alojamentos.
*/

using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Services
{
    public interface IAlojamentoService
    {
        Alojamento ObterPorId(int id);
        IEnumerable<Alojamento> ObterTodos();
        Alojamento AdicionarAlojamento(string nome, string localizacao, TipoQuarto tipoQuarto, int capacidade, int numeroQuartos, decimal preco);
        bool AtualizarAlojamento(Alojamento alojamento);
        bool RemoverAlojamento(int id);
        bool AlterarStatusAlojamento(int id, StatusAlojamento novoStatus);
        bool VerificarDisponibilidade(int id);
        int ObterQuartosDisponiveis(int id, int numeroDeReservas);
        bool EstaDisponivel(int id);
    }
}
