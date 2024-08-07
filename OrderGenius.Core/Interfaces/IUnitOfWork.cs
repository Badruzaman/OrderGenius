﻿using OrderGenius.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
        Task<int> Commit();
        void Rollback();
       // IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
