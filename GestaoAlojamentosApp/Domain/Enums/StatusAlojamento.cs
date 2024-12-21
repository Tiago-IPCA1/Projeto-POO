using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GestaoAlojamentosApp.Domain.Enums
{
    /// <summary>
    /// Enumera��o que define os estados poss�veis de um alojamento no sistema.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]  // Converte o enum para string durante a serializa��o
    public enum StatusAlojamento
    {
        /// <summary>
        /// O alojamento est� dispon�vel para reservas e ocupa��o.
        /// </summary>
        Disponivel,

        /// <summary>
        /// O alojamento est� temporariamente indispon�vel para reservas.
        /// </summary>
        Indisponivel,

        /// <summary>
        /// O alojamento est� em manuten��o ou repara��o e n�o pode ser reservado.
        /// </summary>
        EmManutencao,
    }
}
