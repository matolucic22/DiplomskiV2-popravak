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
        private IPredmetiRepository predmetiGenericReporsitory;

        public PredmetiService(IPredmetiRepository predmetiGenericReporsitory)//povezuje sa PredmetiGenericReporsitory
        {
            this.predmetiGenericReporsitory = predmetiGenericReporsitory;
        }


        public async Task<int> AddAsync(IPredmetDomainModel addObj)
        {
            addObj.Id = Guid.NewGuid();
            return await predmetiGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> AddToBridgeAsync(IPredmetKorisnikDomainModel addObj)
        {
            return await predmetiGenericReporsitory.AddToBridgeAsync(addObj);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await predmetiGenericReporsitory.DeleteAsync(id);
        }

        public async Task<IPredmetDomainModel> GetAsync(Guid id)
        {
            return await predmetiGenericReporsitory.GetAsync(id);
        }

        public async Task<int> UpdateAsync(IPredmetDomainModel updated) 
        {
            return await predmetiGenericReporsitory.UpdateAsync(updated);
        }

        public async Task<IPagedList<IPredmetDomainModel>> FindPredmetiAsync(FilterModel filterModel)
        {
            return await predmetiGenericReporsitory.FindPredmetiAsync(filterModel);
        }
        public async Task<IEnumerable<IPredmetDomainModel>> GetAllImePredmetaAsync()
        {
            return await predmetiGenericReporsitory.GetAllImePredmetaAsync();
        }
        public async Task<IEnumerable<IPredmetDomainModel>> GetAllAsync()
        {
            return await predmetiGenericReporsitory.GetAllAsync();
        }
    }
}
