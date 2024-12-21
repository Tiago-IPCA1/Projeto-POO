using System;
using System.Collections.Generic;

namespace GestaoAlojamentosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface gen�rica que define as assinaturas de m�todos de acesso a dados.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Adiciona uma nova entidade ao reposit�rio.
        /// </summary>
        /// <param name="entity">A entidade que ser� adicionada ao reposit�rio.</param>
        void Adicionar(T entity);

        /// <summary>
        /// Atualiza os dados de uma entidade existente.
        /// </summary>
        /// <param name="entity">A entidade com os dados atualizados.</param>
        /// <returns>Retorna verdadeiro se a atualiza��o foi bem-sucedida, caso contr�rio, retorna falso.</returns>
        bool Atualizar(T entity);

        /// <summary>
        /// Remove uma entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da entidade a ser removida.</param>
        void Remover(object id);

        /// <summary>
        /// Obt�m uma entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da entidade a ser recuperada.</param>
        /// <returns>Retorna a entidade correspondente ao ID, ou null se n�o encontrada.</returns>
        T? ObterPorId(object id);

        /// <summary>
        /// Obt�m todas as entidades cadastradas no reposit�rio.
        /// </summary>
        /// <returns>Uma lista contendo todas as entidades do reposit�rio.</returns>
        List<T> ObterTodos();
    }
}
