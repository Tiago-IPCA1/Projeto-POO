/* 
   @file: IAlojamentoService.cs
   @autor: Tiago Vale
   @data: 14 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Interface com os métodos de serviço para Alojamentos.
*/

using System;
using GestaoAlojamentosApp.Domain.Models.Entities;
using GestaoAlojamentosApp.Domain.Models.Enums;
using System.Collections.Generic;

namespace GestaoAlojamentosApp.Domain.Services.Interfaces
{
    public interface IAlojamentoService
    {
        Alojamento ObterPorId(int id);
        IEnumerable<Alojamento> ObterTodos();
        Alojamento AdicionarAlojamento(string nome, string localizacao, TipoQuarto tipoQuarto, int capacidade, int numeroQuartos, decimal preco);
        bool AtualizarAlojamento(Alojamento alojamento);
        bool RemoverAlojamento(int id);
        bool AlterarStatusAlojamento(int id, StatusAlojamento novoStatus);
        bool VerificarDisponibilidade(int id);
        int ObterQuartosDisponiveis(int id, int numeroDeReservas);
        bool EstaDisponivel(int id);
    }
}
