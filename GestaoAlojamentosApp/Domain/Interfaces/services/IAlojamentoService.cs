using System;
using System.Collections.Generic;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface que define assinatura dos m�todos relativamente � gest�o de alojamentos.
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
        /// <param name="localizacao">Localiza��o do alojamento.</param>
        /// <param name="precoPorNoite">Pre�o por noite do alojamento.</param>
        /// <param name="capacidade">Capacidade m�xima do alojamento.</param>
        /// <param name="numeroDeQuartos">N�mero de quartos no alojamento.</param>
        /// <param name="status">Status atual do alojamento (ex: Dispon�vel, Indispon�vel).</param>
        /// <param name="tipo">Tipo do alojamento (ex: Hotel, Apartamento ou hostel, etc.).</param>
        /// <returns>Retorna verdadeiro se o alojamento for criado com sucesso, falso caso contr�rio.</returns>
        bool CriarAlojamento(string nome, string localizacao, decimal precoPorNoite, int capacidade, int numeroDeQuartos, StatusAlojamento status, TipoAlojamento tipo);

        /// <summary>
        /// Atualiza um alojamento existente.
        /// </summary>
        /// <param name="id">Identificador do alojamento a ser atualizado.</param>
        /// <param name="nome">Novo nome do alojamento.</param>
        /// <param name="localizacao">Nova localiza��o do alojamento.</param>
        /// <param name="precoPorNoite">Novo pre�o por noite.</param>
        /// <param name="capacidade">Nova capacidade m�xima.</param>
        /// <param name="numeroDeQuartos">Novo n�mero de quartos.</param>
        /// <param name="status">Novo status do alojamento.</param>
        /// <param name="tipo">Novo tipo do alojamento.</param>
        /// <returns>Retorna verdadeiro se o alojamento for atualizado com sucesso, falso caso contr�rio.</returns>
        bool AtualizarAlojamento(int id, string nome, string localizacao, decimal precoPorNoite, int capacidade, int numeroDeQuartos, StatusAlojamento status, TipoAlojamento tipo);

        /// <summary>
        /// Remove um alojamento.
        /// </summary>
        /// <param name="id">Identificador do alojamento a ser removido.</param>
        /// <returns>Retorna verdadeiro se o alojamento for removido com sucesso, falso caso contr�rio.</returns>
        bool RemoverAlojamento(int id);

        /// <summary>
        /// Obt�m todos os alojamentos registados.
        /// </summary>
        /// <returns>Lista de todos os alojamentos.</returns>
        List<Alojamento> ObterTodosAlojamentos();

        /// <summary>
        /// Adiciona uma imagem ao alojamento.
        /// </summary>
        /// <param name="idAlojamento">Identificador do alojamento ao qual a imagem ser� adicionada.</param>
        /// <param name="caminhoImagem">Caminho da imagem a ser adicionada.</param>
        /// <returns>Retorna verdadeiro se a imagem for adicionada com sucesso, falso caso contr�rio.</returns>
        bool AdicionarImagem(int idAlojamento, string caminhoImagem);

        /// <summary>
        /// Remove uma imagem do alojamento.
        /// </summary>
        /// <param name="idAlojamento">Identificador do alojamento do qual a imagem ser� removida.</param>
        /// <param name="caminhoImagem">Caminho da imagem a ser removida.</param>
        /// <returns>Retorna verdadeiro se a imagem for removida com sucesso, falso caso contr�rio.</returns>
        bool RemoverImagem(int idAlojamento, string caminhoImagem);

        /// <summary>
        /// Obt�m um alojamento pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador �nico do alojamento.</param>
        /// <returns>Retorna o alojamento correspondente ao ID, ou null se n�o encontrado.</returns>
        Alojamento? ObterAlojamentoPorId(int id);

        /// <summary>
        /// Obt�m um alojamento pelo nome.
        /// </summary>
        /// <param name="nome">Nome do alojamento.</param>
        /// <returns>Retorna o alojamento correspondente ao nome, ou null se n�o encontrado.</returns>
        Alojamento? ObterAlojamentoPorNome(string nome);

        /// <summary>
        /// Obt�m alojamentos pela localiza��o.
        /// </summary>
        /// <param name="localizacao">Localiza��o do alojamento.</param>
        /// <returns>Lista de alojamentos dispon�veis por localiza��o.</returns>
        List<Alojamento> ObterAlojamentosPorLocalizacao(string localizacao);

        /// <summary>
        /// Retorna os alojamentos dispon�veis dentro de um intervalo de datas.
        /// </summary>
        /// <param name="dataInicio">Data de in�cio do intervalo.</param>
        /// <param name="dataFim">Data de fim do intervalo.</param>
        /// <param name="capacidade">Capacidade m�nima do alojamento.</param>
        /// <returns>Lista de alojamentos dispon�veis dentro do intervalo de datas e com a capacidade m�nima.</returns>
        List<Alojamento> AlojamentosDisponiveis(DateTime dataInicio, DateTime dataFim, int capacidade);

        /// <summary>
        /// Altera o status do alojamento.
        /// </summary>
        /// <param name="id">Identificador do alojamento.</param>
        /// <param name="status">Novo status do alojamento (ex: Dispon�vel, Indispon�vel).</param>
        /// <returns>Retorna verdadeiro se o status for alterado com sucesso, falso caso contr�rio.</returns>
        bool AlterarStatusAlojamento(int id, StatusAlojamento status);
    }
}
