using System;
using System.Collections.Generic;

namespace GestaoAlojamentosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface genérica que define as assinaturas de métodos de acesso a dados.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Adiciona uma nova entidade ao repositório.
        /// </summary>
        /// <param name="entity">A entidade que será adicionada ao repositório.</param>
        void Adicionar(T entity);

        /// <summary>
        /// Atualiza os dados de uma entidade existente.
        /// </summary>
        /// <param name="entity">A entidade com os dados atualizados.</param>
        /// <returns>Retorna verdadeiro se a atualização foi bem-sucedida, caso contrário, retorna falso.</returns>
        bool Atualizar(T entity);

        /// <summary>
        /// Remove uma entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da entidade a ser removida.</param>
        void Remover(object id);

        /// <summary>
        /// Obtém uma entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da entidade a ser recuperada.</param>
        /// <returns>Retorna a entidade correspondente ao ID, ou null se não encontrada.</returns>
        T? ObterPorId(object id);

        /// <summary>
        /// Obtém todas as entidades cadastradas no repositório.
        /// </summary>
        /// <returns>Uma lista contendo todas as entidades do repositório.</returns>
        List<T> ObterTodos();
    }
}
