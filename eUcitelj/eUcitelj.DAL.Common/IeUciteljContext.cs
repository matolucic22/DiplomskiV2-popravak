using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Common
{
    public interface IeUciteljContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;//DbSet represent collenction of all entities in db
        DbSet Set(Type entityType);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;//sth like instance on database(you can create only one)
        DbEntityEntry Entry(object entity);
        Task<int> SaveChangesAsync();
    }
}
