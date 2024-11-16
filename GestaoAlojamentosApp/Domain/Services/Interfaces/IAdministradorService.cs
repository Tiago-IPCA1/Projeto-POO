/* 
   @file: IAdministradorService.cs
   @autor: Tiago Vale
   @data: 14 de novembro de 2024
   @email: a27675@alunos.ipca.pt
   @descrição: Interface com os métodos de serviço para Administradores.
*/

using System;                                       
using GestaoAlojamentosApp.Domain.Models.Entities;
using GestaoAlojamentosApp.Domain.Models.Enums;
using System.Collections.Generic;                   

namespace GestaoAlojamentosApp.Domain.Services.Interfaces
{
    public interface IAdministradorService
    {
        Administrador ObterPorId(int id);
        Administrador ObterPorEmail(string email);
        Administrador CriarAdministrador(string nome, string email, string telefone, int idade, string senha);
        bool AtualizarAdministrador(Administrador administrador);
        bool RemoverAdministrador(int id);
        bool AutenticarAdministrador(string email, string senha);
    }
}
