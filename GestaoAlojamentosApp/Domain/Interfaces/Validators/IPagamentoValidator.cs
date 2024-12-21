using System;
using GestaoAlojamentosApp.Domain.Models;

namespace GestaoAlojamentosApp.Domain.Interfaces.Validators
{
    /// <summary>
    /// Interface que define as assinaturas de m�todos relativos � valida��o de pagamentos.
    /// Esta interface cont�m m�todos que garantem que os pagamentos sejam v�lidos de acordo com as regras de neg�cios.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public interface IPagamentoValidator
    {
        /// <summary>
        /// Valida um objeto de pagamento de acordo com as regras de neg�cios.
        /// </summary>
        /// <param name="pagamento">Objeto de pagamento a ser validado.</param>
        /// <returns>Retorna verdadeiro se o pagamento for v�lido, caso contr�rio retorna falso.</returns>
        bool ValidarPagamento(Pagamento pagamento);
    }
}
