using System;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Validators
{
    /// <summary>
    /// Interface que define as assinaturas de métodos relativos à validação de reservas.
    /// Esta interface contém métodos que garantem que as propriedades das reservas sejam válidas de acordo com as regras de negócios.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IReservaValidator
    {
        /// <summary>
        /// Valida se o cliente existe e pode fazer a reserva.
        /// </summary>
        /// <param name="clienteId">Identificador único do cliente.</param>
        /// <returns>Retorna verdadeiro se o cliente for válido, caso contrário retorna falso.</returns>
        bool ValidarCliente(int clienteId);

        /// <summary>
        /// Valida se o alojamento está disponível para a reserva.
        /// </summary>
        /// <param name="alojamentoId">Identificador único do alojamento.</param>
        /// <returns>Retorna verdadeiro se o alojamento for válido, caso contrário retorna falso.</returns>
        bool ValidarAlojamento(int alojamentoId);

        /// <summary>
        /// Valida se as datas da reserva são válidas.
        /// </summary>
        /// <param name="dataInicio">Data de início da reserva.</param>
        /// <param name="dataFim">Data de fim da reserva.</param>
        /// <returns>Retorna verdadeiro se as datas forem válidas, caso contrário retorna falso.</returns>
        bool ValidarDatas(DateTime dataInicio, DateTime dataFim);

        /// <summary>
        /// Valida se o número de pessoas é compatível com a capacidade do alojamento.
        /// </summary>
        /// <param name="alojamentoId">Identificador único do alojamento.</param>
        /// <param name="numeroDePessoas">Número de pessoas para a reserva.</param>
        /// <returns>Retorna verdadeiro se o número de pessoas for válido, caso contrário retorna falso.</returns>
        bool ValidarNumeroDePessoas(int alojamentoId, int numeroDePessoas);

        /// <summary>
        /// Valida todos os aspectos da reserva de um cliente para um alojamento.
        /// </summary>
        /// <param name="clienteId">Identificador único do cliente.</param>
        /// <param name="alojamentoId">Identificador único do alojamento.</param>
        /// <param name="dataInicio">Data de início da reserva.</param>
        /// <param name="dataFim">Data de fim da reserva.</param>
        /// <param name="numeroDePessoas">Número de pessoas para a reserva.</param>
        /// <returns>Retorna verdadeiro se a reserva for válida, caso contrário retorna falso.</returns>
        bool ValidarReserva(int clienteId, int alojamentoId, DateTime dataInicio, DateTime dataFim, int numeroDePessoas);
    }
}
