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
        protected IUceniciRepository PredmetiGenericReporsitory { get; set; }

        public UceniciService(IUceniciRepository predmetiGenericReporsitory)
        {
            this.PredmetiGenericReporsitory = predmetiGenericReporsitory;
        }

        public async Task<int> AddAsync(IUceniciDomainModel addObj)
        {
            addObj.UcenikId = Guid.NewGuid();
            return await PredmetiGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await PredmetiGenericReporsitory.DeleteAsync(Id);
        }

        public async Task<IUceniciDomainModel> GetAsync(Guid Id)
        {
            return await PredmetiGenericReporsitory.GetAsync(Id);
        }

        public async Task<IEnumerable<IUceniciDomainModel>> GetAllAsync()
        {
            return await PredmetiGenericReporsitory.GetAllAsync();
        }

        public async Task<int> UpdateAsync(IUceniciDomainModel updated)
        {
            return await PredmetiGenericReporsitory.UpdateAsync(updated);
        }
    }
}
