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

        public async Task<IEnumerable<IKvizDomainModel>> GetAll()
        {
            return await KvizGenericReporsitory.GetAllAsync();
        }

        public async Task<IKvizDomainModel> Get(Guid Id)
        {
            return await KvizGenericReporsitory.GetAsync(Id);
        }

        public async Task<int> Add(IKvizDomainModel addObj)
        {
            return await KvizGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> Update(IKvizDomainModel updated)
        {
            return await KvizGenericReporsitory.UpdateAsync(updated);
        }

        public async Task<int> Delete(Guid Id)
        {
            return await KvizGenericReporsitory.DeleteAsync(Id);
        }
    }
}
