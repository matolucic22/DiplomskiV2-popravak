using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service.Common
{
    public interface IUceniciService
    {
        Task<IEnumerable<IUceniciDomainModel>> GetAllAsync();//vraća IEnimerable polje podataka
        Task<IUceniciDomainModel> GetAsync(Guid id);
        Task<int> AddAsync(IUceniciDomainModel addObj);
        Task<int> UpdateAsync(IUceniciDomainModel updated);//obavi i returna samo save
        Task<int> DeleteAsync(Guid id);
    }
}
