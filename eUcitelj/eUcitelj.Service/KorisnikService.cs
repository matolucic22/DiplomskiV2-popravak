using eUcitelj.Model.Common;
using eUcitelj.Reporsitory.Common;
using eUcitelj.Service.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service
{
    public class KorisnikService : IKorisnikService
    {
        /* VAŠE PITANJE: jel potrebno u servisu da sve metode bugu async i da se nešto awaita?
         *  Npr Get metoda, ili GetAll metoda? dovoljno da vraća task */

        //ODGOVOR: Await je marker koji označi da se zaustavi izvršavanje kooda dok se funkcija ispred koje je on ne provede do kraja. Kad funkcija završi, kood će se nastaviti.
        //         Generalno u ovoj aplikaciji unutar Service nije potrebno koristiti asinkrone metode zato što se samo proslijedi podatak iz KorisnikRepositorija u KorisnikController. 
        //         Asinkrone metode se koriste ako se mora čekati rezultat neke akcije(radnje) nad podatkom ili je važno neku funkciju obaviti prije neke druge što ovdje nije slučaj.
        //         Async sam obrisao sa Get i GetAll metoda kako ste rekli i aplikacija funkcionira normalno. 
        private IKorisnikRepository korisnikGenericReporsitory;
        public KorisnikService(IKorisnikRepository korisnikGenericReporsitory)
        {
            this.korisnikGenericReporsitory = korisnikGenericReporsitory;
        }

        public async Task<int> AddAsync(IKorisnikDomainModel addObj)
        {
            try
            {
                addObj.Id = Guid.NewGuid();
                return await korisnikGenericReporsitory.AddAsync(addObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await korisnikGenericReporsitory.DeleteAsync(id);
        }

        public Task<IKorisnikDomainModel> Get(Guid id)//nije async
        {
            return korisnikGenericReporsitory.GetAsync(id);
        }

        public async Task<int> UpdateAsync(IKorisnikDomainModel updated)
        {
            return await korisnikGenericReporsitory.UpdateAsync(updated);
        }
        
        public async Task<IKorisnikDomainModel> FindByUserNameAsync(string korisnickoIme)
        {
            return await korisnikGenericReporsitory.GetByUsernameAsync(korisnickoIme);
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetAllKorisnicko_imeAsync()
        {
            return await korisnikGenericReporsitory.GetAllKorisnicko_imeAsync();
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetAllUcenikAsync()
        {
            return await korisnikGenericReporsitory.GetAllUcenikAsync();
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetNepotvrdenoAsync()
        {
            return await korisnikGenericReporsitory.GetNepotvrdenoAsync();
        }
        public async Task<IEnumerable<IKorisnikDomainModel>> GetPotvrdenoAsync()
        {
            return await korisnikGenericReporsitory.GetPotvrdenoAsync();
        }
        public async Task<IEnumerable<IKorisnikDomainModel>> GetOdbijenoAsync()
        {
            return await korisnikGenericReporsitory.GetOdbijenoAsync();
        }

    }
}
