using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service.Common
{
    public interface IKvizService
    {
        Task<IEnumerable<IKvizDomainModel>> GetAll();//vraća IEnimerable polje podataka
        Task<IKvizDomainModel> Get(Guid Id);
        Task<int> Add(IKvizDomainModel addObj);
        Task<int> Update(IKvizDomainModel updated);
        Task<int> Delete(Guid Id);
    }
}
