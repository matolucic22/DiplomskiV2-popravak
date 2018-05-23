using eUcitelj.Common;
using eUcitelj.Model.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service.Common
{
    public interface IPredmetiService
    {
        Task<IEnumerable<IPredmetiDomainModel>> GetAllAsync();//vraća IEnimerable polje podataka
        Task<IPredmetiDomainModel> GetAsync(Guid Id);
        Task<int> AddAsync(IPredmetiDomainModel addObj);
        Task<int> AddToBridgeAsync(IPredmetKorisnikDomainModel addObj);
        Task<int> UpdateAsync(IPredmetiDomainModel updated);//obavi i returna samo save
        Task<int> DeleteAsync(Guid Id);
        Task<IPagedList<IPredmetiDomainModel>> FindAsync(FilterModel filterModel);
    }
}
