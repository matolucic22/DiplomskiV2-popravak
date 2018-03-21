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
   public class UceniciService:IUceniciService
    {
        protected IUceniciGenericReporsitory PredmetiGenericReporsitory { get; set; }

        public UceniciService(IUceniciGenericReporsitory predmetiGenericReporsitory)
        {
            this.PredmetiGenericReporsitory = predmetiGenericReporsitory;
        }

        public async Task<int> Add(IUceniciDomainModel addObj)
        {
            return await PredmetiGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> Delete(Guid Id)
        {
            return await PredmetiGenericReporsitory.DeleteAsync(Id);
        }

        public async Task<IUceniciDomainModel> Get(Guid Id)
        {
            return await PredmetiGenericReporsitory.GetAsync(Id);
        }

        public async Task<IEnumerable<IUceniciDomainModel>> GetAll()
        {
            return await PredmetiGenericReporsitory.GetAllAsync();
        }

        public async Task<int> Update(IUceniciDomainModel updated)
        {
            return await PredmetiGenericReporsitory.UpdateAsync(updated);
        }
    }
}
