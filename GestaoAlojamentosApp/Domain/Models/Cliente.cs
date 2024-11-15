/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Classe que representa um cliente 
*/

using System;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Models
{
    public class Cliente : PessoaBase
    {
        public Cliente(string nome, string email, string telefone, int idade)
            : base(nome, email, telefone, idade, TipoUtilizador.Cliente)
        { }
    }
}
