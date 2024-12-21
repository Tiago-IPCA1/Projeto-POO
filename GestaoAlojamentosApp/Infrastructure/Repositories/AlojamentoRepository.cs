using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using GestaoAlojamentosApp.Domain.Models;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;
using GestaoAlojamentosApp.Domain.Enums;
using System.Linq;

namespace GestaoAlojamentosApp.Infrastructure.Repositories
{
    /// <summary>
    /// Reposit�rio respons�vel pelo gestao dos alojamentos.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public class AlojamentoRepository : RepositoryBase<Alojamento>, IAlojamentoRepository
    {
        private List<Reserva> _reservas; // Lista de reservas

        // Construtor
        public AlojamentoRepository(string? filePath = null)
            : base(filePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Infrastructure\Database", "alojamentos.json"))
        {
            _reservas = new List<Reserva>(); // Inicializa a lista de reservas
        }

        #region M�todos de Consulta

        /// <summary>
        /// Obt�m um Alojamento pelo nome.
        /// </summary>
        public Alojamento? ObterAlojamentoPorNome(string nome)
        {
            return _cache?.Find(a => a.Nome == nome);
        }

        /// <summary>
        /// Obt�m os Alojamentos dispon�veis para uma reserva.
        /// </summary>
        public List<Alojamento> ObterAlojamentosDisponiveis(DateTime dataInicio, DateTime dataFim, int capacidade)
        {
            var alojamentosDisponiveis = new List<Alojamento>();

            foreach (var alojamento in _cache)
            {
                if (alojamento.Capacidade < capacidade)
                    continue;

                bool isDisponivel = true;
                foreach (var reserva in _reservas)
                {
                    if (reserva.AlojamentoId == alojamento.Id &&
                        reserva.Status == StatusReserva.Pendente &&
                        ((reserva.DataInicio < dataFim && reserva.DataFim > dataInicio)))
                    {
                        isDisponivel = false;
                        break;
                    }
                }

                if (isDisponivel)
                {
                    alojamentosDisponiveis.Add(alojamento);
                }
            }

            return alojamentosDisponiveis;
        }

        /// <summary>
        /// Obt�m um Alojamento pelo nome e localiza��o.
        /// </summary>
        public Alojamento? ObterAlojamentoPorNomeELocalizacao(string nome, string localizacao)
        {
            return _cache?.Find(a => a.Nome == nome && a.Localizacao == localizacao);
        }

        /// <summary>
        /// Obt�m todos os Alojamentos de uma determinada localiza��o.
        /// </summary>
        public List<Alojamento> ObterAlojamentosPorLocalizacao(string localizacao)
        {
            return _cache?.FindAll(a => a.Localizacao == localizacao) ?? new List<Alojamento>();
        }

        #endregion

        #region M�todos de Atualiza��o de Status

        /// <summary>
        /// Atualiza o status de um Alojamento.
        /// </summary>
        public void AtualizarStatus(int id, StatusAlojamento status)
        {
            var alojamento = ObterPorId(id);
            if (alojamento != null)
            {
                alojamento.Status = status;
                Atualizar(alojamento); // Atualiza o alojamento ap�s a altera��o de status
            }
            else
            {
                throw new InvalidOperationException("Alojamento n�o encontrado para altera��o de status.");
            }
        }

        #endregion

        #region Implementa��o do M�todo Abstrato

        // Implementa��o do m�todo abstrato para obter o ID de um Alojamento
        protected override object GetEntityId(Alojamento entity)
        {
            return entity.Id; 
        }

        #endregion
    }
}
