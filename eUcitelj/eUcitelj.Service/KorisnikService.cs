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
    public class KorisnikService : IKorisnikService
    {
        protected IKorisnikGenericReporsitory KorisnikGenericReporsitory { set; get; }
        public KorisnikService(IKorisnikGenericReporsitory korisnikGenericReporsitory)
        {
            this.KorisnikGenericReporsitory = korisnikGenericReporsitory;
        }
        public async Task<int> Add(IKorisnikDomainModel addObj)
        {
            return await KorisnikGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> Delete(Guid Id)
        {
            return await KorisnikGenericReporsitory.DeleteAsync(Id);
        }

        public async Task<IKorisnikDomainModel> Get(Guid Id)
        {
            return await KorisnikGenericReporsitory.GetAsync(Id);
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetAll()
        {
            return await KorisnikGenericReporsitory.GetAllAsync();
        }

        public async Task<int> Update(IKorisnikDomainModel updated)
        {
            return await KorisnikGenericReporsitory.UpdateAsync(updated);
        }
        //find user by username
        public async Task<IKorisnikDomainModel> FindByUserName(string korisnicko_ime)
        {
            return await KorisnikGenericReporsitory.GetByUsername(korisnicko_ime);
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetAllKorisnicko_ime()
        {
            return await KorisnikGenericReporsitory.GetAllKorisnicko_ime();
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetAllKorisnikId()
        {
            return await KorisnikGenericReporsitory.GetAllKorisnikId();
        }

    }
}
