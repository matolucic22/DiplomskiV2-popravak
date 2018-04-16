using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory.Common
{
    public interface IKorisnikRepository
    {
        Task<IEnumerable<IKorisnikDomainModel>> GetAllAsync();
        Task<IKorisnikDomainModel> GetAsync(Guid Id);
        Task<int> AddAsync(IKorisnikDomainModel addObj);
        Task<int> UpdateAsync(IKorisnikDomainModel updated);
        Task<int> DeleteAsync(Guid Id);
        Task<IKorisnikDomainModel> GetByUsernameAsync(string korisnicko_ime);
        Task<IEnumerable<IKorisnikDomainModel>> GetAllKorisnicko_imeAsync();
        Task<IEnumerable<IKorisnikDomainModel>> GetAllKorisnikIdAsync();
    }
}
