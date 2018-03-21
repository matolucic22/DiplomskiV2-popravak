using eUcitelj.Model.Common;
using eUcitelj.Reporsitory.Common;
using eUcitelj.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service
{
    public class PredmetiService:IPredmetiService
    {
        protected IPredmetiGenericReporsitory PredmetiGenericReporsitory { get; set; }

        public PredmetiService(IPredmetiGenericReporsitory predmetiGenericReporsitory)//povezuje sa PredmetiGenericReporsitory
        {
            this.PredmetiGenericReporsitory = predmetiGenericReporsitory;
        }


        public async Task<int> Add(IPredmetiDomainModel addObj)
        {
            return await PredmetiGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> Delete(Guid Id)
        {
            return await PredmetiGenericReporsitory.DeleteAsync(Id);
        }

        public async Task<IPredmetiDomainModel> Get(Guid Id)
        {
            return await PredmetiGenericReporsitory.GetAsync(Id);
        }

        public async Task<IEnumerable<IPredmetiDomainModel>> GetAll()
        {
            return await PredmetiGenericReporsitory.GetAllAsync();
        }

        public async Task<int> Update(IPredmetiDomainModel updated)
        {
            return await PredmetiGenericReporsitory.UpdateAsync(updated);
        }
    }
}
