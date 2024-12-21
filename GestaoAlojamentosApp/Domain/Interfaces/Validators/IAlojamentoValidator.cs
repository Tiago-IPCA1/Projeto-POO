using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Validators
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos relativos � valida��o de alojamentos.
    /// Esta interface cont�m m�todos que garantem que as propriedades dos alojamentos sejam v�lidas de acordo com as regras de neg�cios.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IAlojamentoValidator
    {
        /// <summary>
        /// Valida o nome de um alojamento.
        /// </summary>
        /// <param name="nome">Nome do alojamento a ser validado.</param>
        /// <returns>Retorna true se o nome for v�lido, false caso contr�rio.</returns>
        bool ValidarNome(string nome);

        /// <summary>
        /// Valida a localiza��o de um alojamento.
        /// </summary>
        /// <param name="localizacao">Localiza��o do alojamento a ser validada.</param>
        /// <returns>Retorna true se a localiza��o for v�lida, false caso contr�rio.</returns>
        bool ValidarLocalizacao(string localizacao);

        /// <summary>
        /// Valida o pre�o por noite de um alojamento.
        /// </summary>
        /// <param name="precoPorNoite">Pre�o por noite a ser validado.</param>
        /// <returns>Retorna true se o pre�o for v�lido, false caso contr�rio.</returns>
        bool ValidarPrecoPorNoite(decimal precoPorNoite);

        /// <summary>
        /// Valida a capacidade m�xima de um alojamento.
        /// </summary>
        /// <param name="capacidade">Capacidade m�xima de pessoas a ser validada.</param>
        /// <returns>Retorna true se a capacidade for v�lida, false caso contr�rio.</returns>
        bool ValidarCapacidade(int capacidade);

        /// <summary>
        /// Valida se existe um alojamento duplicado com o mesmo nome e localiza��o.
        /// </summary>
        /// <param name="nome">Nome do alojamento a ser verificado.</param>
        /// <param name="localizacao">Localiza��o do alojamento a ser verificada.</param>
        /// <param name="idAlojamentoExcluir">ID de um alojamento que pode ser exclu�do da valida��o (opcional).</param>
        /// <returns>Retorna true se um alojamento duplicado for encontrado, false caso contr�rio.</returns>
        bool ValidarAlojamentoDuplicado(string nome, string localizacao, int idAlojamentoExcluir = 0);

        /// <summary>
        /// Valida todas as propriedades de um objeto Alojamento.
        /// </summary>
        /// <param name="alojamento">Objeto Alojamento a ser validado.</param>
        /// <returns>Retorna true se o alojamento for v�lido, false caso contr�rio.</returns>
        bool ValidarAlojamento(Alojamento alojamento);
    }
}
