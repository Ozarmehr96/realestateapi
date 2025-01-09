using Ijora.Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Ijora.Data.Infrastructure
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<Type, Type> _typeSearchCache = new ConcurrentDictionary<Type, Type>();
        private readonly ILogger<RepositoryProvider> _logger;

        public RepositoryProvider(IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            _serviceProvider = serviceProvider;
            _logger = loggerFactory.CreateLogger<RepositoryProvider>();
        }

        public T GetRepository<T>() where T : IRepository
        {
            var repositoryType = typeof(T);
            T repository = default;
            if (_typeSearchCache.TryGetValue(repositoryType, out Type repositoryImplType))
            {
                try
                {
                    repository = CreateRepository<T>(repositoryImplType);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Get repository object from cache failed.{Environment.NewLine}" +
                        $"RepositoryType: {repositoryType}.{Environment.NewLine}" +
                        $"RepositoryImplType {repositoryImplType}.{Environment.NewLine}" +
                        $"The content of cache dictionary: {Environment.NewLine}"
                        + string.Join(Environment.NewLine, _typeSearchCache.Select(a => $"{a.Key}: {a.Value}")));

                    var resolvedType = ResolveRepositoryType<T>(repositoryType);
                    repository = CreateRepository<T>(resolvedType);
                }
            }
            else
            {
                var resolvedType = ResolveRepositoryType<T>(repositoryType);
                if (resolvedType != null && !_typeSearchCache.ContainsKey(repositoryType))
                {
                    try
                    {
                        _typeSearchCache.Add(repositoryType, resolvedType);
                    }
                    catch (ArgumentException)
                    {
                    }

                    repository = CreateRepository<T>(resolvedType);
                }
                else
                    repository = CreateRepository<T>(resolvedType);
            }
            return repository;
        }

        private Type ResolveRepositoryType<T>(Type repositoryType) where T : IRepository
        {
            foreach (var type in GetType().Assembly.GetTypes())
            {
                if (repositoryType.IsAssignableFrom(type) && type.IsClass)
                {
                    return type;
                }
            }
            return null;
        }

        private T CreateRepository<T>(Type implementationType) where T : IRepository
        {
            return (T)ActivatorUtilities.CreateInstance(_serviceProvider.CreateScope().ServiceProvider, implementationType);
        }
    }
}
