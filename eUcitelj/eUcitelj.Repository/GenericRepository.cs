
using eUcitelj.DAL;
using eUcitelj.Reporsitory.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class GenericRepository : IGenericRepository
    {
        protected eUciteljContext Context { get; set; }

        public GenericRepository(eUciteljContext context)//konstruktor da svakim pokretanjem stvori objekt od contexta
        {
            this.Context = context;
        }      

        public async Task<int> AddAsync<T>(T addObj) where T : class
        {
            try
            {
                Context.Set<T>().Add(addObj);
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
             
        }

        public async Task<int> DeleteAsync<T>(Guid Id) where T : class
        {
            try
            {
                T entity = await Context.Set<T>().FindAsync(Id);
                Context.Set<T>().Remove(entity);
                return await Context.SaveChangesAsync();
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
                return await Context.Set<T>().ToListAsync<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<T> GetAsync<T>(Guid Id) where T : class
        {
            try
            {
                T entity = await Context.Set<T>().FindAsync(Id);
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
                Context.Set<T>().AddOrUpdate(updated);
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public IQueryable<T> GetQueryable<T>() where T:class
        {
            try
            {
                return Context.Set<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
