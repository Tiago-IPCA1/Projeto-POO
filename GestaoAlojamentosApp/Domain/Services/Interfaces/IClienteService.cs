/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Interface com os métodos de serviço para Clientes.
*/

using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Services
{
    public interface IClienteService
    {
        Cliente ObterPorId(int id);
        Cliente ObterPorEmail(string email);
        List<Cliente> ObterTodosClientes();
        Cliente CriarCliente(string nome, string email, string telefone, int idade);
        bool AtualizarCliente(Cliente cliente);
        bool RemoverCliente(int id);
    }
}
