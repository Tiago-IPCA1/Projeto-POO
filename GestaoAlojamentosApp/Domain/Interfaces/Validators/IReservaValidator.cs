using System;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Validators
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos relativos � valida��o de reservas.
    /// Esta interface cont�m m�todos que garantem que as propriedades das reservas sejam v�lidas de acordo com as regras de neg�cios.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IReservaValidator
    {
        /// <summary>
        /// Valida se o cliente existe e pode fazer a reserva.
        /// </summary>
        /// <param name="clienteId">Identificador �nico do cliente.</param>
        /// <returns>Retorna verdadeiro se o cliente for v�lido, caso contr�rio retorna falso.</returns>
        bool ValidarCliente(int clienteId);

        /// <summary>
        /// Valida se o alojamento est� dispon�vel para a reserva.
        /// </summary>
        /// <param name="alojamentoId">Identificador �nico do alojamento.</param>
        /// <returns>Retorna verdadeiro se o alojamento for v�lido, caso contr�rio retorna falso.</returns>
        bool ValidarAlojamento(int alojamentoId);

        /// <summary>
        /// Valida se as datas da reserva s�o v�lidas.
        /// </summary>
        /// <param name="dataInicio">Data de in�cio da reserva.</param>
        /// <param name="dataFim">Data de fim da reserva.</param>
        /// <returns>Retorna verdadeiro se as datas forem v�lidas, caso contr�rio retorna falso.</returns>
        bool ValidarDatas(DateTime dataInicio, DateTime dataFim);

        /// <summary>
        /// Valida se o n�mero de pessoas � compat�vel com a capacidade do alojamento.
        /// </summary>
        /// <param name="alojamentoId">Identificador �nico do alojamento.</param>
        /// <param name="numeroDePessoas">N�mero de pessoas para a reserva.</param>
        /// <returns>Retorna verdadeiro se o n�mero de pessoas for v�lido, caso contr�rio retorna falso.</returns>
        bool ValidarNumeroDePessoas(int alojamentoId, int numeroDePessoas);

        /// <summary>
        /// Valida todos os aspectos da reserva de um cliente para um alojamento.
        /// </summary>
        /// <param name="clienteId">Identificador �nico do cliente.</param>
        /// <param name="alojamentoId">Identificador �nico do alojamento.</param>
        /// <param name="dataInicio">Data de in�cio da reserva.</param>
        /// <param name="dataFim">Data de fim da reserva.</param>
        /// <param name="numeroDePessoas">N�mero de pessoas para a reserva.</param>
        /// <returns>Retorna verdadeiro se a reserva for v�lida, caso contr�rio retorna falso.</returns>
        bool ValidarReserva(int clienteId, int alojamentoId, DateTime dataInicio, DateTime dataFim, int numeroDePessoas);
    }
}
