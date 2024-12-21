using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using GestaoAlojamentosApp.Domain.Interfaces.Repositories;

namespace GestaoAlojamentosApp.Infrastructure.Repositories
{
    /// <summary>
    /// Reposit�rio respons�vel pela gest�o das entidades gen�ricas.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly string _filePath; // Caminho do ficheiro espec�fico para cada tipo de entidade
        private readonly object _lock = new object(); // Controle de concorr�ncia para leitura e escrita
        protected List<T> _cache; // Cache em mem�ria para reduzir I/O no ficheiro

        /// <summary>
        /// Construtor para inicializar o reposit�rio com o caminho do ficheiro de dados espec�fico para a entidade.
        /// </summary>
        /// <param name="filePath">Caminho do ficheiro onde os dados da entidade ser�o armazenados.</param>
        public RepositoryBase(string filePath)
        {
            _filePath = Path.GetFullPath(filePath);
            CriarDiretorioSeNaoExistir(); // Verifica e cria o diret�rio se necess�rio
            _cache = CarregarDeFicheiro(); // Carrega os dados do ficheiro para o cache na inicializa��o
        }

        #region M�todos de Cria��o e Atualiza��o

        /// <summary>
        /// Adiciona uma nova entidade ao reposit�rio.
        /// </summary>
        public void Adicionar(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entidade n�o pode ser nula.");

            if (EntidadeJaExiste(entity))
                throw new EntityAlreadyExistsException("Entidade com esse ID j� existe.");

            _cache.Add(entity);
            GuardarEmFicheiro();
        }

        /// <summary>
        /// Atualiza uma entidade existente no reposit�rio.
        /// </summary>
        public bool Atualizar(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entidade n�o pode ser nula.");

            var existingEntity = ObterPorId(GetEntityId(entity));
            if (existingEntity != null)
            {
                _cache.Remove(existingEntity);
                _cache.Add(entity);
                GuardarEmFicheiro();
                return true;
            }

            return false;
        }

        #endregion

        #region M�todos de Remo��o

        /// <summary>
        /// Remove uma entidade pelo seu ID.
        /// </summary>
        public void Remover(object id)
        {
            var entity = _cache.FirstOrDefault(e => GetEntityId(e).Equals(id));
            if (entity != null)
            {
                _cache.Remove(entity);
                GuardarEmFicheiro();
            }
            else
            {
                throw new EntityNotFoundException("Entidade n�o encontrada para remo��o.");
            }
        }

        #endregion

        #region M�todos de Consulta

        /// <summary>
        /// Obt�m uma entidade pelo seu ID.
        /// </summary>
        public T? ObterPorId(object id)
        {
            return _cache.FirstOrDefault(e => GetEntityId(e).Equals(id));
        }

        /// <summary>
        /// Obt�m todas as entidades registadas no reposit�rio.
        /// </summary>
        public List<T> ObterTodos()
        {
            return _cache;
        }

        #endregion

        #region M�todos de Carregar e Guardar em Ficheiro

        /// <summary>
        /// Carrega as entidades de um arquivo JSON espec�fico para a entidade.
        /// </summary>
        private List<T> CarregarDeFicheiro()
        {
            lock (_lock) // Garantir que s� um thread leia o ficheiro por vez
            {
                if (!File.Exists(_filePath))
                    return new List<T>(); // Se o ficheiro n�o existir, retornar uma lista vazia

                try
                {
                    var json = File.ReadAllText(_filePath);
                    return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
                }
                catch (Exception ex)
                {
                    throw new IOException("Erro ao carregar os dados do arquivo.", ex);
                }
            }
        }

        /// <summary>
        /// Guarda as entidades no arquivo de dados espec�fico para a entidade.
        /// </summary>
        private void GuardarEmFicheiro()
        {
            lock (_lock) // Garantir que s� um thread escreva no ficheiro por vez
            {
                try
                {
                    var json = JsonConvert.SerializeObject(_cache, Formatting.Indented);
                    File.WriteAllText(_filePath, json); // Sobrescreve o ficheiro com a lista atualizada
                }
                catch (Exception ex)
                {
                    throw new IOException("Erro ao salvar os dados no arquivo.", ex);
                }
            }
        }

        #endregion

        #region M�todos de Suporte

        /// <summary>
        /// Extrai o ID de uma entidade.
        /// </summary>
        protected abstract object GetEntityId(T entity);

        /// <summary>
        /// Verifica se a entidade j� existe no reposit�rio.
        /// </summary>
        private bool EntidadeJaExiste(T entity)
        {
            return _cache.Any(e => GetEntityId(e).Equals(GetEntityId(entity)));
        }

        /// <summary>
        /// Cria o diret�rio onde o ficheiro de dados ser� armazenado, se n�o existir.
        /// </summary>
        private void CriarDiretorioSeNaoExistir()
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        #endregion
    }

    #region Exce��es Personalizadas

    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message) { }
    }

    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string message) : base(message) { }
    }

    #endregion
}
