using System;

namespace GestaoAlojamentosApp.Utils.CriarIds
{
    /// <summary>
    /// Classe responsável pela geração de IDs únicos para diferentes entidades no sistema, como Alojamento, Reserva, CheckIn, Pagamento e Cliente.
    /// Os métodos desta classe garantem a criação de IDs sequenciais e exclusivos para cada tipo de entidade.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public static class GeradorId
    {
        private static int ultimoIdAlojamento = 0;
        private static int ultimoIdReserva = 0;
        private static int ultimoIdCheckIn = 0;
        private static int ultimoIdPagamento = 0;
        private static int ultimoIdCliente = 0;

        // Método para gerar ID de Alojamento
        public static int GerarIdAlojamento()
        {
            return ++ultimoIdAlojamento;
        }

        // Método para gerar ID de Reserva
        public static int GerarIdReserva()
        {
            return ++ultimoIdReserva;
        }

        // Método para gerar ID de CheckIn
        public static int GerarIdCheckIn()
        {
            return ++ultimoIdCheckIn;
        }

        // Método para gerar ID de Pagamento
        public static int GerarIdPagamento()
        {
            return ++ultimoIdPagamento;
        }

        // Método para gerar ID de Cliente
        public static int GerarIdCliente()
        {
            return ++ultimoIdCliente;
        }
    }
}
