using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory.Common
{
    public interface IReporsitory
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<T> GetAsync<T>(Guid Id) where T : class;
        Task<int> AddAsync<T>(T addObj) where T : class;
        Task<int> UpdateAsync<T>(T updated) where T : class;
        Task<int> DeleteAsync<T>(Guid Id) where T : class;
        IQueryable<T> GetQueryable<T>() where T : class;
    }
}
