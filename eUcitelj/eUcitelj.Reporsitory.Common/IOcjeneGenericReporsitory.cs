using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory.Common
{
   public interface IOcjeneGenericReporsitory
    {
        Task<IEnumerable<IOcjeneDomainModel>> GetAllAsync();//vraća IEnimerable polje podataka
        Task<IOcjeneDomainModel> GetAsync(Guid Id);
        Task<int> AddAsync(IOcjeneDomainModel addObj);
        Task<int> UpdateAsync(IOcjeneDomainModel updated);//obavi i returna samo save
        Task<int> DeleteAsync(Guid Id);
    }
}
