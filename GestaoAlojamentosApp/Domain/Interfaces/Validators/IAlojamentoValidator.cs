using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Validators
{
    /// <summary>
    /// Interface que define as assinaturas de métodos relativos à validação de alojamentos.
    /// Esta interface contém métodos que garantem que as propriedades dos alojamentos sejam válidas de acordo com as regras de negócios.
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
        /// <returns>Retorna true se o nome for válido, false caso contrário.</returns>
        bool ValidarNome(string nome);

        /// <summary>
        /// Valida a localização de um alojamento.
        /// </summary>
        /// <param name="localizacao">Localização do alojamento a ser validada.</param>
        /// <returns>Retorna true se a localização for válida, false caso contrário.</returns>
        bool ValidarLocalizacao(string localizacao);

        /// <summary>
        /// Valida o preço por noite de um alojamento.
        /// </summary>
        /// <param name="precoPorNoite">Preço por noite a ser validado.</param>
        /// <returns>Retorna true se o preço for válido, false caso contrário.</returns>
        bool ValidarPrecoPorNoite(decimal precoPorNoite);

        /// <summary>
        /// Valida a capacidade máxima de um alojamento.
        /// </summary>
        /// <param name="capacidade">Capacidade máxima de pessoas a ser validada.</param>
        /// <returns>Retorna true se a capacidade for válida, false caso contrário.</returns>
        bool ValidarCapacidade(int capacidade);

        /// <summary>
        /// Valida se existe um alojamento duplicado com o mesmo nome e localização.
        /// </summary>
        /// <param name="nome">Nome do alojamento a ser verificado.</param>
        /// <param name="localizacao">Localização do alojamento a ser verificada.</param>
        /// <param name="idAlojamentoExcluir">ID de um alojamento que pode ser excluído da validação (opcional).</param>
        /// <returns>Retorna true se um alojamento duplicado for encontrado, false caso contrário.</returns>
        bool ValidarAlojamentoDuplicado(string nome, string localizacao, int idAlojamentoExcluir = 0);

        /// <summary>
        /// Valida todas as propriedades de um objeto Alojamento.
        /// </summary>
        /// <param name="alojamento">Objeto Alojamento a ser validado.</param>
        /// <returns>Retorna true se o alojamento for válido, false caso contrário.</returns>
        bool ValidarAlojamento(Alojamento alojamento);
    }
}
