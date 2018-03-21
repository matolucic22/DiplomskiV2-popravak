using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service.Common
{
    public interface IOcjeneService
    {
        Task<IEnumerable<IOcjeneDomainModel>> GetAll();
        Task<IOcjeneDomainModel> Get(Guid Id);
        Task<int> Add(IOcjeneDomainModel addObj);
        Task<int> Update(IOcjeneDomainModel updated);
        Task<int> Delete(Guid Id);
    }
}
