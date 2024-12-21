using System;
using GestaoAlojamentosApp.Domain.Enums;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Services;

namespace GestaoAlojamentosApp.App.ViewModels
{
    /// <summary>
    /// Classe respons�vel por representar o modelo de dados de uma reserva.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class ReservaViewModel
    {
        #region Propriedades

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string? ClienteEmail { get; set; } = string.Empty;
        public string? ClienteNome { get; set; } = string.Empty;
        public int AlojamentoId { get; set; }
        public string? AlojamentoNome { get; set; } = string.Empty;
        public string? AlojamentoLocalizacao { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal PrecoTotal { get; set; }
        public StatusReserva Status { get; set; }
        public int NumeroDePessoas { get; set; }

        #endregion

        #region M�todos de Convers�o

        /// <summary>
        /// M�todo para converter uma entidade de Reserva em um objeto ReservaViewModel.
        /// Realiza valida��o para garantir que os dados de cliente e alojamento estejam presentes.
        /// </summary>
        public static ReservaViewModel DeReservaParaViewModel(Reserva reserva, IClienteService clienteService, IAlojamentoService alojamentoService)
        {
            if (reserva == null)
                throw new ArgumentNullException(nameof(reserva), "Reserva n�o pode ser nula.");

            // Obtenha os dados do cliente e alojamento
            var cliente = clienteService.ObterClientePorId(reserva.ClienteId);
            var alojamento = alojamentoService.ObterAlojamentoPorId(reserva.AlojamentoId);

            // Verifique se os dados est�o presentes
            if (cliente == null)
                throw new ArgumentException("Cliente n�o encontrado.");
            if (alojamento == null)
                throw new ArgumentException("Alojamento n�o encontrado.");

            return new ReservaViewModel
            {
                Id = reserva.Id,
                ClienteId = reserva.ClienteId,
                ClienteEmail = cliente.Email, // Atribui o e-mail do cliente
                ClienteNome = cliente.Nome,  // Atribui o nome do cliente
                AlojamentoId = reserva.AlojamentoId,
                AlojamentoNome = alojamento.Nome, // Atribui o nome do alojamento
                AlojamentoLocalizacao = alojamento.Localizacao, // Atribui a localiza��o
                DataInicio = reserva.DataInicio,
                DataFim = reserva.DataFim,
                PrecoTotal = reserva.PrecoTotal,
                Status = reserva.Status,
                NumeroDePessoas = reserva.NumeroDePessoas
            };
        }

        /// <summary>
        /// M�todo para converter um objeto ReservaViewModel de volta para uma entidade Reserva.
        /// Valida se os IDs do cliente e do alojamento s�o v�lidos.
        /// </summary>
        public Reserva ParaReserva()
        {
            if (ClienteId <= 0 || AlojamentoId <= 0)
                throw new ArgumentException("ClienteId e AlojamentoId devem ser v�lidos.");

            return new Reserva(ClienteId, AlojamentoId, DataInicio, DataFim, PrecoTotal, NumeroDePessoas);
        }

        #endregion
    }
}
