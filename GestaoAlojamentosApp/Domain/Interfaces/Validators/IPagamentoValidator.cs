using System;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Validators
{
    /// <summary>
    /// Interface que define as assinaturas de métodos relativos à validação de pagamentos.
    /// Esta interface contém métodos que garantem que os pagamentos sejam válidos de acordo com as regras de negócios.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IPagamentoValidator
    {
        /// <summary>
        /// Valida um objeto de pagamento de acordo com as regras de negócios.
        /// </summary>
        /// <param name="pagamento">Objeto de pagamento a ser validado.</param>
        /// <returns>Retorna verdadeiro se o pagamento for válido, caso contrário retorna falso.</returns>
        bool ValidarPagamento(Pagamento pagamento);
    }
}
