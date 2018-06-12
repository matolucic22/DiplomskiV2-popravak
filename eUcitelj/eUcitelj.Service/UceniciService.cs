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
        private IUceniciRepository predmetiGenericReporsitory;

        public UceniciService(IUceniciRepository predmetiGenericReporsitory)
        {
            this.predmetiGenericReporsitory = predmetiGenericReporsitory;
        }

        public async Task<int> AddAsync(IUceniciDomainModel addObj)
        {
            addObj.UcenikId = Guid.NewGuid();
            return await predmetiGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await predmetiGenericReporsitory.DeleteAsync(id);
        }

        public async Task<IUceniciDomainModel> GetAsync(Guid id)
        {
            return await predmetiGenericReporsitory.GetAsync(id);
        }

        public async Task<IEnumerable<IUceniciDomainModel>> GetAllAsync()
        {
            return await predmetiGenericReporsitory.GetAllAsync();
        }

        public async Task<int> UpdateAsync(IUceniciDomainModel updated)
        {
            return await predmetiGenericReporsitory.UpdateAsync(updated);
        }
    }
}
