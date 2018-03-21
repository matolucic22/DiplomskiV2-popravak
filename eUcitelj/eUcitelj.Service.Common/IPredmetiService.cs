using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service.Common
{
    public interface IPredmetiService
    {
        Task<IEnumerable<IPredmetiDomainModel>> GetAll();//vraća IEnimerable polje podataka
        Task<IPredmetiDomainModel> Get(Guid Id);
        Task<int> Add(IPredmetiDomainModel addObj);
        Task<int> Update(IPredmetiDomainModel updated);//obavi i returna samo save
        Task<int> Delete(Guid Id);
    }
}
