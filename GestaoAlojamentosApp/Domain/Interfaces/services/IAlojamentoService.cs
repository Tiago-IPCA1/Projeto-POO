using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface que define assinatura dos métodos relativamente à gestão de alojamentos.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IAlojamentoService
    {
        /// <summary>
        /// Cria um novo alojamento.
        /// </summary>
        /// <param name="nome">Nome do alojamento.</param>
        /// <param name="localizacao">Localização do alojamento.</param>
        /// <param name="precoPorNoite">Preço por noite do alojamento.</param>
        /// <param name="capacidade">Capacidade máxima do alojamento.</param>
        /// <param name="numeroDeQuartos">Número de quartos no alojamento.</param>
        /// <param name="status">Status atual do alojamento (ex: Disponível, Indisponível).</param>
        /// <param name="tipo">Tipo do alojamento (ex: Hotel, Apartamento ou hostel, etc.).</param>
        /// <returns>Retorna verdadeiro se o alojamento for criado com sucesso, falso caso contrário.</returns>
        bool CriarAlojamento(string nome, string localizacao, decimal precoPorNoite, int capacidade, int numeroDeQuartos, StatusAlojamento status, TipoAlojamento tipo);

        /// <summary>
        /// Atualiza um alojamento existente.
        /// </summary>
        /// <param name="id">Identificador do alojamento a ser atualizado.</param>
        /// <param name="nome">Novo nome do alojamento.</param>
        /// <param name="localizacao">Nova localização do alojamento.</param>
        /// <param name="precoPorNoite">Novo preço por noite.</param>
        /// <param name="capacidade">Nova capacidade máxima.</param>
        /// <param name="numeroDeQuartos">Novo número de quartos.</param>
        /// <param name="status">Novo status do alojamento.</param>
        /// <param name="tipo">Novo tipo do alojamento.</param>
        /// <returns>Retorna verdadeiro se o alojamento for atualizado com sucesso, falso caso contrário.</returns>
        bool AtualizarAlojamento(int id, string nome, string localizacao, decimal precoPorNoite, int capacidade, int numeroDeQuartos, StatusAlojamento status, TipoAlojamento tipo);

        /// <summary>
        /// Remove um alojamento.
        /// </summary>
        /// <param name="id">Identificador do alojamento a ser removido.</param>
        /// <returns>Retorna verdadeiro se o alojamento for removido com sucesso, falso caso contrário.</returns>
        bool RemoverAlojamento(int id);

        /// <summary>
        /// Obtém todos os alojamentos registados.
        /// </summary>
        /// <returns>Lista de todos os alojamentos.</returns>
        List<Alojamento> ObterTodosAlojamentos();

        /// <summary>
        /// Adiciona uma imagem ao alojamento.
        /// </summary>
        /// <param name="idAlojamento">Identificador do alojamento ao qual a imagem será adicionada.</param>
        /// <param name="caminhoImagem">Caminho da imagem a ser adicionada.</param>
        /// <returns>Retorna verdadeiro se a imagem for adicionada com sucesso, falso caso contrário.</returns>
        bool AdicionarImagem(int idAlojamento, string caminhoImagem);

        /// <summary>
        /// Remove uma imagem do alojamento.
        /// </summary>
        /// <param name="idAlojamento">Identificador do alojamento do qual a imagem será removida.</param>
        /// <param name="caminhoImagem">Caminho da imagem a ser removida.</param>
        /// <returns>Retorna verdadeiro se a imagem for removida com sucesso, falso caso contrário.</returns>
        bool RemoverImagem(int idAlojamento, string caminhoImagem);

        /// <summary>
        /// Obtém um alojamento pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador único do alojamento.</param>
        /// <returns>Retorna o alojamento correspondente ao ID, ou null se não encontrado.</returns>
        Alojamento? ObterAlojamentoPorId(int id);

        /// <summary>
        /// Obtém um alojamento pelo nome.
        /// </summary>
        /// <param name="nome">Nome do alojamento.</param>
        /// <returns>Retorna o alojamento correspondente ao nome, ou null se não encontrado.</returns>
        Alojamento? ObterAlojamentoPorNome(string nome);

        /// <summary>
        /// Obtém alojamentos pela localização.
        /// </summary>
        /// <param name="localizacao">Localização do alojamento.</param>
        /// <returns>Lista de alojamentos disponíveis por localização.</returns>
        List<Alojamento> ObterAlojamentosPorLocalizacao(string localizacao);

        /// <summary>
        /// Retorna os alojamentos disponíveis dentro de um intervalo de datas.
        /// </summary>
        /// <param name="dataInicio">Data de início do intervalo.</param>
        /// <param name="dataFim">Data de fim do intervalo.</param>
        /// <param name="capacidade">Capacidade mínima do alojamento.</param>
        /// <returns>Lista de alojamentos disponíveis dentro do intervalo de datas e com a capacidade mínima.</returns>
        List<Alojamento> AlojamentosDisponiveis(DateTime dataInicio, DateTime dataFim, int capacidade);

        /// <summary>
        /// Altera o status do alojamento.
        /// </summary>
        /// <param name="id">Identificador do alojamento.</param>
        /// <param name="status">Novo status do alojamento (ex: Disponível, Indisponível).</param>
        /// <returns>Retorna verdadeiro se o status for alterado com sucesso, falso caso contrário.</returns>
        bool AlterarStatusAlojamento(int id, StatusAlojamento status);
    }
}
