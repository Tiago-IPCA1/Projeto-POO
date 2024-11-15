/* Autor: Tiago Vale
   Data: 15 de novembro de 2024
   Email: a27675@alunos.ipca.pt
   Descrição: Interface com os métodos de serviço para Administradores.
*/

using GestaoAlojamentosApp.Domain.Models;
using System.Collections.Generic;

namespace GestaoAlojamentosApp.Domain.Services
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
