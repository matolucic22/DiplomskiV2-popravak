using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service.Common
{
    public interface IKorisnikService
    {
        Task<IEnumerable<IKorisnikDomainModel>> GetAll();//task je asinkrona metoda
        Task<IKorisnikDomainModel> Get(Guid Id);
        Task<int> Add(IKorisnikDomainModel addObj);
        Task<int> Update(IKorisnikDomainModel updated);
        Task<int> Delete(Guid Id);
        Task<IKorisnikDomainModel> FindByUserName(string korisnicko_ime);
        Task<IEnumerable<IKorisnikDomainModel>> GetAllKorisnicko_ime();
        Task<IEnumerable<IKorisnikDomainModel>> GetAllKorisnikId();
    }
}
