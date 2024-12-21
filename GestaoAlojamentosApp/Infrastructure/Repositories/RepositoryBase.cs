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
    /// Repositório responsável pela gestão das entidades genéricas.
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly string _filePath; // Caminho do ficheiro específico para cada tipo de entidade
        private readonly object _lock = new object(); // Controle de concorrência para leitura e escrita
        protected List<T> _cache; // Cache em memória para reduzir I/O no ficheiro

        /// <summary>
        /// Construtor para inicializar o repositório com o caminho do ficheiro de dados específico para a entidade.
        /// </summary>
        /// <param name="filePath">Caminho do ficheiro onde os dados da entidade serão armazenados.</param>
        public RepositoryBase(string filePath)
        {
            _filePath = Path.GetFullPath(filePath);
            CriarDiretorioSeNaoExistir(); // Verifica e cria o diretório se necessário
            _cache = CarregarDeFicheiro(); // Carrega os dados do ficheiro para o cache na inicialização
        }

        #region Métodos de Criação e Atualização

        /// <summary>
        /// Adiciona uma nova entidade ao repositório.
        /// </summary>
        public void Adicionar(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entidade não pode ser nula.");

            if (EntidadeJaExiste(entity))
                throw new EntityAlreadyExistsException("Entidade com esse ID já existe.");

            _cache.Add(entity);
            GuardarEmFicheiro();
        }

        /// <summary>
        /// Atualiza uma entidade existente no repositório.
        /// </summary>
        public bool Atualizar(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entidade não pode ser nula.");

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

        #region Métodos de Remoção

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
                throw new EntityNotFoundException("Entidade não encontrada para remoção.");
            }
        }

        #endregion

        #region Métodos de Consulta

        /// <summary>
        /// Obtém uma entidade pelo seu ID.
        /// </summary>
        public T? ObterPorId(object id)
        {
            return _cache.FirstOrDefault(e => GetEntityId(e).Equals(id));
        }

        /// <summary>
        /// Obtém todas as entidades registadas no repositório.
        /// </summary>
        public List<T> ObterTodos()
        {
            return _cache;
        }

        #endregion

        #region Métodos de Carregar e Guardar em Ficheiro

        /// <summary>
        /// Carrega as entidades de um arquivo JSON específico para a entidade.
        /// </summary>
        private List<T> CarregarDeFicheiro()
        {
            lock (_lock) // Garantir que só um thread leia o ficheiro por vez
            {
                if (!File.Exists(_filePath))
                    return new List<T>(); // Se o ficheiro não existir, retornar uma lista vazia

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
        /// Guarda as entidades no arquivo de dados específico para a entidade.
        /// </summary>
        private void GuardarEmFicheiro()
        {
            lock (_lock) // Garantir que só um thread escreva no ficheiro por vez
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

        #region Métodos de Suporte

        /// <summary>
        /// Extrai o ID de uma entidade.
        /// </summary>
        protected abstract object GetEntityId(T entity);

        /// <summary>
        /// Verifica se a entidade já existe no repositório.
        /// </summary>
        private bool EntidadeJaExiste(T entity)
        {
            return _cache.Any(e => GetEntityId(e).Equals(GetEntityId(entity)));
        }

        /// <summary>
        /// Cria o diretório onde o ficheiro de dados será armazenado, se não existir.
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

    #region Exceções Personalizadas

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
