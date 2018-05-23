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
        protected IKvizRepository KvizGenericReporsitory { get; set; }

        public KvizService(IKvizRepository kvizGenericReporsitory)
        {
            this.KvizGenericReporsitory = kvizGenericReporsitory;
        }

        public async Task<IEnumerable<IKvizDomainModel>> GetAllAsync()
        {
            return await KvizGenericReporsitory.GetAllAsync();
        }

        public async Task<IKvizDomainModel> GetAsync(Guid Id)
        {
            return await KvizGenericReporsitory.GetAsync(Id);
        }

        public async Task<int> AddAsync(IKvizDomainModel addObj)
        {
            addObj.KvizId = Guid.NewGuid();
            return await KvizGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> UpdateAsync(IKvizDomainModel updated)
        {
            return await KvizGenericReporsitory.UpdateAsync(updated);
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await KvizGenericReporsitory.DeleteAsync(Id);
        }
    }
}
