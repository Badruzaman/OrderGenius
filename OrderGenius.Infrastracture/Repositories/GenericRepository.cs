﻿using Microsoft.EntityFrameworkCore;
using OrderGenius.Core.Entities;
using OrderGenius.Core.Interfaces;
using OrderGenius.Core.Specifications;
using OrderGenius.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGenius.Infrastracture.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MsSqlContext _storeContext;
        public GenericRepository(MsSqlContext storeContext)
        {
            _storeContext = storeContext;
        }
        public void DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            try
            {
                return await _storeContext.Set<T>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _storeContext.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        //Specification Pattern
        public async Task<T> GetEntityWithSpec(ISpecifications<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }
        public async Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }
        public async Task<int> CountAsync(ISpecifications<T> specifications)
        {
            return await ApplySpecification(specifications).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecifications<T> specifications)
        {
            return SpecificationEvaluator<T>.GetQuery(_storeContext.Set<T>().AsQueryable(), specifications);
        }
        public void Add(T entity)
        {
            _storeContext.Add<T>(entity);
        }
        public void Update(T entity)
        {
            _storeContext.Attach<T>(entity);
            _storeContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _storeContext.Set<T>().Remove(entity);
        }
    }
}
