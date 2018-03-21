using eUcitelj.DAL;
using eUcitelj.DAL.Common;
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
    public class Reporsitory : IReporsitory
    {
        protected IeUciteljContext Context { get; set; }

        public Reporsitory(IeUciteljContext context)//konstruktor da svakim pokretanjem stvori objekt od contexta
        {
            this.Context = context;
        }      

        public async Task<int> AddAsync<T>(T addObj) where T : class
        {           
            Context.Set<T>().Add(addObj);
            return await Context.SaveChangesAsync(); 
        }

        public async Task<int> DeleteAsync<T>(Guid Id) where T : class
        {
            T entity = await Context.Set<T>().FindAsync(Id);
            Context.Set<T>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return await Context.Set<T>().ToListAsync<T>();
        }

        public async Task<T> GetAsync<T>(Guid Id) where T : class
        {
            T entity = await Context.Set<T>().FindAsync(Id);
            return entity;
        }

        public async Task<int> UpdateAsync<T>(T updated) where T : class
        {
             Context.Set<T>().AddOrUpdate(updated);
            return await Context.SaveChangesAsync();
        }

        public IQueryable<T> GetQueryable<T>() where T:class
        {
            return Context.Set<T>();
        }
    }
}
