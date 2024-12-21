using System;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Validators
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos relativos � valida��o de clientes.
    /// Esta interface cont�m m�todos que garantem que as propriedades dos clientes sejam v�lidas de acordo com as regras de neg�cios.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IClienteValidator
    {
        /// <summary>
        /// Valida o nome do cliente.
        /// </summary>
        /// <param name="nome">Nome do cliente a ser validado.</param>
        /// <returns>Retorna verdadeiro se o nome for v�lido, caso contr�rio retorna falso.</returns>
        bool ValidarNome(string nome);

        /// <summary>
        /// Valida o email do cliente.
        /// </summary>
        /// <param name="email">Email do cliente a ser validado.</param>
        /// <returns>Retorna verdadeiro se o email for v�lido, caso contr�rio retorna falso.</returns>
        bool ValidarEmail(string email);

        /// <summary>
        /// Valida o telefone do cliente.
        /// </summary>
        /// <param name="telefone">Telefone do cliente a ser validado.</param>
        /// <returns>Retorna verdadeiro se o telefone for v�lido, caso contr�rio retorna falso.</returns>
        bool ValidarTelefone(string telefone);

        /// <summary>
        /// Valida a idade do cliente.
        /// </summary>
        /// <param name="idade">Idade do cliente a ser validada.</param>
        /// <returns>Retorna verdadeiro se a idade for v�lida, caso contr�rio retorna falso.</returns>
        bool ValidarIdade(int idade);

        /// <summary>
        /// Verifica se j� existe um cliente com o mesmo email para atualiza��o de dados.
        /// </summary>
        /// <param name="email">Email do cliente a ser validado.</param>
        /// <param name="id">Identificador do cliente.</param>
        /// <returns>Retorna verdadeiro se o cliente com o mesmo email j� existir, caso contr�rio retorna falso.</returns>
        bool ValidarClienteExistenteParaAtualizacao(string email, int id);

        /// <summary>
        /// Valida o cliente completo.
        /// </summary>
        /// <param name="cliente">Objeto cliente a ser validado.</param>
        /// <returns>Retorna verdadeiro se o cliente for v�lido, caso contr�rio retorna falso.</returns>
        bool ValidarCliente(Cliente cliente);
    }
}
