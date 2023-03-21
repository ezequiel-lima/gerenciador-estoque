﻿using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstoque.Infra.Data
{
    public class UnitOfWork : IRepositoryFactory, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Dictionary<Type, object> _serviceProviderCache;

        public UnitOfWork(GerenciamentoEstoqueDataContext dbContext, IServiceProvider serviceProvider)
        {
            Context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public DbContext Context { get; }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public IReadRepository<TEntity> GetReadRepository<TEntity>() where TEntity : class
        {
            if (_serviceProviderCache == null)
                _serviceProviderCache = new Dictionary<Type, object>();

            var type = typeof(IReadRepository<TEntity>);
            if (!_serviceProviderCache.ContainsKey(type))
                _serviceProviderCache[type] = _serviceProvider.GetService(type);

            return _serviceProviderCache[type] as IReadRepository<TEntity>;
        }

        public IWriteRepository<TEntity> GetWriteRepository<TEntity>() where TEntity : class
        {
            if (_serviceProviderCache == null)
                _serviceProviderCache = new Dictionary<Type, object>();

            var type = typeof(IWriteRepository<TEntity>);
            if (!_serviceProviderCache.ContainsKey(type))
                _serviceProviderCache[type] = _serviceProvider.GetService(type);

            return _serviceProviderCache[type] as IWriteRepository<TEntity>;
        }
    }
}