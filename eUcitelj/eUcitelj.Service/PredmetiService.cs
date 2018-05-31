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


        public async Task<int> AddAsync(IPredmetDomainModel addObj)
        {
            addObj.Id = Guid.NewGuid();
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

        public async Task<IPredmetDomainModel> GetAsync(Guid Id)
        {
            return await PredmetiGenericReporsitory.GetAsync(Id);
        }

        public async Task<int> UpdateAsync(IPredmetDomainModel updated) 
        {
            return await PredmetiGenericReporsitory.UpdateAsync(updated);
        }

        public async Task<IPagedList<IPredmetDomainModel>> FindPredmetiAsync(FilterModel filterModel)
        {
            return await PredmetiGenericReporsitory.SortingPagingFilteringAsync(filterModel);
        }
        public async Task<IEnumerable<IPredmetDomainModel>> GetAllImePredmetaAsync()
        {
            return await PredmetiGenericReporsitory.GetAllImePredmetaAsync();
        }
        public async Task<IEnumerable<IPredmetDomainModel>> GetAllAsync()
        {
            return await PredmetiGenericReporsitory.GetAllAsync();
        }
    }
}
