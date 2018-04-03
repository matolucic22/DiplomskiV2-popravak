using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory.Common
{
   public interface IPredmetiRepository
    {
        Task<IEnumerable<IPredmetiDomainModel>> GetAllAsync();//vraća IEnumerable polje podataka
        Task<IPredmetiDomainModel> GetAsync(Guid Id);
        Task<int> AddAsync(IPredmetiDomainModel addObj);
        Task<int> UpdateAsync(IPredmetiDomainModel updated);//obavi i returna samo save
        Task<int> DeleteAsync(Guid Id);
    }
}
