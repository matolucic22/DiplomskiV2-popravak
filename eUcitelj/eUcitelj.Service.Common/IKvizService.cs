using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service.Common
{
    public interface IKvizService
    {
        Task<IEnumerable<IKvizDomainModel>> GetAllAsync();//vraća IEnimerable polje podataka
        Task<IKvizDomainModel> GetAsync(Guid id);
        Task<int> AddAsync(IKvizDomainModel addObj);
        Task<int> UpdateAsync(IKvizDomainModel updated);
        Task<int> DeleteAsync(Guid id);
    }
}
