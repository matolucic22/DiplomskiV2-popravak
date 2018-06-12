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
    public class KvizService:IKvizService
    {
        private IKvizRepository kvizGenericReporsitory;

        public KvizService(IKvizRepository kvizGenericReporsitory)
        {
            this.kvizGenericReporsitory = kvizGenericReporsitory;
        }

        public async Task<IEnumerable<IKvizDomainModel>> GetAllAsync()
        {
            return await kvizGenericReporsitory.GetAllAsync();
        }

        public async Task<IKvizDomainModel> GetAsync(Guid id)
        {
            return await kvizGenericReporsitory.GetAsync(id);
        }

        public async Task<int> AddAsync(IKvizDomainModel addObj)
        {
            addObj.KvizId = Guid.NewGuid();
            return await kvizGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> UpdateAsync(IKvizDomainModel updated)
        {
            return await kvizGenericReporsitory.UpdateAsync(updated);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await kvizGenericReporsitory.DeleteAsync(id);
        }
    }
}
