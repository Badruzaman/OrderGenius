﻿using OrderGenius.Core.Entities;
using OrderGenius.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task<T> GetEntityWithSpec(ISpecifications<T> specification);
        Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> specification);
        Task<int> CountAsync(ISpecifications<T> specifications);
        void DeleteAsync(T entity);
        void UpdateAsync(T entity);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
