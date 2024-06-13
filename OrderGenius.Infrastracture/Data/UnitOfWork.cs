using Microsoft.EntityFrameworkCore;
using OrderGenius.Core.Entities;
using OrderGenius.Core.Interfaces;
using OrderGenius.Infrastracture.Repositories;
using System.Collections;

namespace OrderGenius.Infrastracture.Data
{
    // https://medium.com/@edin.sahbaz/implementing-the-unit-of-work-pattern-in-clean-architecture-with-net-core-53efb7f9d4d
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MsSqlContext _storeContext;
        private Hashtable _repositories;
        private Dictionary<Type, object> _repository;
        public UnitOfWork(MsSqlContext storeContext)
        {
            _storeContext = storeContext;
            _repository = new Dictionary<Type, object>();
        }
        public async Task<int> Complete()
        {
            return await _storeContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _storeContext.Dispose();
        }
        //public IGenericRepository<TEntity> repository<TEntity>() where TEntity : BaseEntity
        //{
        //    if (_repositories == null)
        //        _repositories = new Hashtable();
        //    var Type = typeof(TEntity).Name;
        //    if (!_repositories.ContainsKey(Type))
        //    {
        //        var repositiryType = typeof(GenericRepository<>);
        //        var repositoryInstance = Activator.CreateInstance(repositiryType.MakeGenericType(typeof(TEntity)), _storeContext);
        //        _repositories.Add(Type, repositoryInstance);
        //    }
        //    return (IGenericRepository<TEntity>)_repositories[Type];
        //}
        public IGenericRepository<TEntity> repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repository.ContainsKey(typeof(TEntity)))
            {
                return (IGenericRepository<TEntity>)_repository[typeof(TEntity)];
            }
            var repository = new GenericRepository<TEntity>(_storeContext);
            _repository.Add(typeof(TEntity), repository);
            return repository;
        }
        public async Task<int> Commit()
        {
          return await _storeContext.SaveChangesAsync();
        }
        public void Rollback()
        {
            // Rollback changes if needed
        }
    }
}
