using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service.Common
{
    public interface IUceniciService
    {
        Task<IEnumerable<IUceniciDomainModel>> GetAll();//vraća IEnimerable polje podataka
        Task<IUceniciDomainModel> Get(Guid Id);
        Task<int> Add(IUceniciDomainModel addObj);
        Task<int> Update(IUceniciDomainModel updated);//obavi i returna samo save
        Task<int> Delete(Guid Id);
    }
}
