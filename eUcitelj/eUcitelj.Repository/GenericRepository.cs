
using eUcitelj.DAL;
using eUcitelj.Reporsitory.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private eUciteljContext context;

        public GenericRepository(eUciteljContext context)//konstruktor da svakim pokretanjem stvori objekt od contexta
        {
            this.context = context;
        }      

        public Task<int> AddAsync<T>(T addObj) where T : class
        {
            try
            {
                context.Set<T>().Add(addObj);
                return context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
             
        }

        public async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            try
            {
                T entity = await context.Set<T>().FindAsync(id);
                context.Set<T>().Remove(entity);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            try
            {
                return await context.Set<T>().ToListAsync<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<T> GetAsync<T>(Guid id) where T : class
        {
            try
            {
                T entity = await context.Set<T>().FindAsync(id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<int> UpdateAsync<T>(T updated) where T : class
        {
            try
            {
                context.Set<T>().AddOrUpdate(updated);
                return await context.SaveChangesAsync(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IQueryable<T> GetQueryable<T>() where T : class
        {
            try
            {
                return context.Set<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
