using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service.Common
{
    public interface IPredmetKorisnikService
    {
        Task<IEnumerable<IPredmetKorisnikDomainModel>> GetAllAsync();//vraća IEnimerable polje podataka
        Task<IPredmetKorisnikDomainModel> GetAsync(Guid id);
        Task<int> AddAsync(IPredmetKorisnikDomainModel addObj);
        Task<int> UpdateAsync(IPredmetKorisnikDomainModel updated);
        Task<int> DeleteAsync(Guid id);
    }
}
