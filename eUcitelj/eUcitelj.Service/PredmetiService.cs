using eUcitelj.Common;
using eUcitelj.Model.Common;
using eUcitelj.Reporsitory.Common;
using eUcitelj.Service.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service
{
    public class PredmetiService:IPredmetiService
    {
        protected IPredmetiRepository PredmetiGenericReporsitory { get; set; }

        public PredmetiService(IPredmetiRepository predmetiGenericReporsitory)//povezuje sa PredmetiGenericReporsitory
        {
            this.PredmetiGenericReporsitory = predmetiGenericReporsitory;
        }


        public async Task<int> AddAsync(IPredmetiDomainModel addObj)
        {
            return await PredmetiGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> AddToBridgeAsync(IPredmetKorisnikDomainModel addObj)
        {
            return await PredmetiGenericReporsitory.AddToBridgeAsync(addObj);
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await PredmetiGenericReporsitory.DeleteAsync(Id);
        }

        public async Task<IPredmetiDomainModel> GetAsync(Guid Id)
        {
            return await PredmetiGenericReporsitory.GetAsync(Id);
        }

        public async Task<IEnumerable<IPredmetiDomainModel>> GetAllAsync()
        {
            return await PredmetiGenericReporsitory.GetAllAsync();
        }

        public async Task<int> UpdateAsync(IPredmetiDomainModel updated)
        {
            return await PredmetiGenericReporsitory.UpdateAsync(updated);
        }

        public async Task<IPagedList<IPredmetiDomainModel>> FindAsync(FilterModel filterModel)
        {
            return await PredmetiGenericReporsitory.SortingPagingFilteringAsync(filterModel);
        }
    }
}
