/* @file: Cliente.cs
   @autor: Tiago Vale
   @data: 5 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Classe que representa um cliente.
*/

using System;
using GestaoAlojamentosApp.Domain.Models.Enums;
using GestaoAlojamentosApp.Utils.Validacoes;
using GestaoAlojamentosApp.Utils.CriarIds;

namespace GestaoAlojamentosApp.Domain.Models.Entities
{
    public class Cliente : PessoaBase
    {
        public Cliente(string nome, string email, string telefone, int idade)
            : base(nome, email, telefone, idade, TipoUtilizador.Cliente)
        { }
    }
}
