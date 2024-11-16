/* 
   @file: IClienteService.cs
   @autor: Tiago Vale
   @data: 14 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Interface com os métodos de serviço para Clientes.
*/

using System;
using GestaoAlojamentosApp.Domain.Models.Entities;
using GestaoAlojamentosApp.Domain.Models.Enums;
using System.Collections.Generic;

namespace GestaoAlojamentosApp.Domain.Services.Interfaces
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
