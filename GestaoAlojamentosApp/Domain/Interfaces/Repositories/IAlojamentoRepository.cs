using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface que define as assinaturas de métodos de acesso a dados para alojamentos.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IAlojamentoRepository : IRepositoryBase<Alojamento>
    {

        /// <summary>
        /// Obtém uma lista de alojamentos disponíveis dentro de um intervalo de datas e capacidade mínima.
        /// </summary>
        /// <param name="dataInicio">A data de início do intervalo de disponibilidade.</param>
        /// <param name="dataFim">A data de fim do intervalo de disponibilidade.</param>
        /// <param name="capacidade">A capacidade mínima de pessoas para o alojamento.</param>
        /// <returns>Uma lista de alojamentos disponíveis dentro do intervalo de datas e capacidade.</returns>
        List<Alojamento> ObterAlojamentosDisponiveis(DateTime dataInicio, DateTime dataFim, int capacidade);

        /// <summary>
        /// Obtém um alojamento pelo nome e localização.
        /// </summary>
        /// <param name="nome">O nome do alojamento a ser buscado.</param>
        /// <param name="localizacao">A localização do alojamento a ser procurado.</param>
        /// <returns>O alojamento que corresponde ao nome e localização fornecidos, ou null se não encontrado.</returns>
        Alojamento? ObterAlojamentoPorNomeELocalizacao(string nome, string localizacao);

        /// <summary>
        /// Atualiza o status de um alojamento.
        /// </summary>
        /// <param name="id">O identificador único do alojamento.</param>
        /// <param name="status">O novo status do alojamento.</param>
        void AtualizarStatus(int id, StatusAlojamento status);

        /// <summary>
        /// Obtém um alojamento pelo nome.
        /// </summary>
        /// <param name="nome">O nome do alojamento a ser procurado.</param>
        /// <returns>O alojamento correspondente ao nome fornecido, ou null se não encontrado.</returns>
        Alojamento? ObterAlojamentoPorNome(string nome);

        /// <summary>
        /// Obtém uma lista de alojamentos em uma localização específica.
        /// </summary>
        /// <param name="localizacao">A localização dos alojamentos a serem procurados.</param>
        /// <returns>Uma lista de alojamentos que estão na localização devida.</returns>
        List<Alojamento> ObterAlojamentosPorLocalizacao(string localizacao);
    }
}
