using eUcitelj.Common;
using eUcitelj.Model.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory.Common
{
   public interface IPredmetiRepository
    {
        Task<IPredmetDomainModel> GetAsync(Guid Id);
        Task<int> AddAsync(IPredmetDomainModel addObj);
        Task<int> AddToBridgeAsync(IPredmetKorisnikDomainModel addObj);
        Task<int> UpdateAsync(IPredmetDomainModel updated);//obavi i returna samo save
        Task<int> DeleteAsync(Guid Id);
        Task<IPagedList<IPredmetDomainModel>> SortingPagingFilteringAsync(FilterModel filterModel);
        Task<IEnumerable<IPredmetDomainModel>> GetAllImePredmetaAsync();
        Task<IEnumerable<IPredmetDomainModel>> GetAllAsync();
    }
}
