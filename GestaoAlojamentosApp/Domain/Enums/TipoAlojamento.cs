using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GestaoAlojamentosApp.Domain.Enums
{
    /// <summary>
    /// Enumeração que representa os diferentes tipos de alojamentos.
    /// Autor: Tiago Vale
    /// Email: a27676@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]  // Converte o enum para string na serialização
    public enum TipoAlojamento
    {
        /// <summary>
        /// Representa um apartamento.
        /// </summary>
        Apartamento,

        /// <summary>
        /// Representa uma casa.
        /// </summary>
        Casa,

        /// <summary>
        /// Representa um hotel.
        /// </summary>
        Hotel,

        /// <summary>
        /// Representa um resort.
        /// </summary>
        Resort,

        /// <summary>
        /// Representa uma villa.
        /// </summary>
        Villa,

        /// <summary>
        /// Representa uma pousada.
        /// </summary>
        Pousada,  

        /// <summary>
        /// Representa um hostel.
        /// </summary>
        Hostel,   

        /// <summary>
        /// Representa um camping.
        /// </summary>
        Camping   
    }
}
