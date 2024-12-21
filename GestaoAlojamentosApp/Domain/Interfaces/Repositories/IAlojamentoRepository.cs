using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos de acesso a dados para alojamentos.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IAlojamentoRepository : IRepositoryBase<Alojamento>
    {

        /// <summary>
        /// Obt�m uma lista de alojamentos dispon�veis dentro de um intervalo de datas e capacidade m�nima.
        /// </summary>
        /// <param name="dataInicio">A data de in�cio do intervalo de disponibilidade.</param>
        /// <param name="dataFim">A data de fim do intervalo de disponibilidade.</param>
        /// <param name="capacidade">A capacidade m�nima de pessoas para o alojamento.</param>
        /// <returns>Uma lista de alojamentos dispon�veis dentro do intervalo de datas e capacidade.</returns>
        List<Alojamento> ObterAlojamentosDisponiveis(DateTime dataInicio, DateTime dataFim, int capacidade);

        /// <summary>
        /// Obt�m um alojamento pelo nome e localiza��o.
        /// </summary>
        /// <param name="nome">O nome do alojamento a ser buscado.</param>
        /// <param name="localizacao">A localiza��o do alojamento a ser procurado.</param>
        /// <returns>O alojamento que corresponde ao nome e localiza��o fornecidos, ou null se n�o encontrado.</returns>
        Alojamento? ObterAlojamentoPorNomeELocalizacao(string nome, string localizacao);

        /// <summary>
        /// Atualiza o status de um alojamento.
        /// </summary>
        /// <param name="id">O identificador �nico do alojamento.</param>
        /// <param name="status">O novo status do alojamento.</param>
        void AtualizarStatus(int id, StatusAlojamento status);

        /// <summary>
        /// Obt�m um alojamento pelo nome.
        /// </summary>
        /// <param name="nome">O nome do alojamento a ser procurado.</param>
        /// <returns>O alojamento correspondente ao nome fornecido, ou null se n�o encontrado.</returns>
        Alojamento? ObterAlojamentoPorNome(string nome);

        /// <summary>
        /// Obt�m uma lista de alojamentos em uma localiza��o espec�fica.
        /// </summary>
        /// <param name="localizacao">A localiza��o dos alojamentos a serem procurados.</param>
        /// <returns>Uma lista de alojamentos que est�o na localiza��o devida.</returns>
        List<Alojamento> ObterAlojamentosPorLocalizacao(string localizacao);
    }
}
