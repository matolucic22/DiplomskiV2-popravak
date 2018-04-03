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
        protected IKorisnikRepository KorisnikGenericReporsitory { set; get; }
        public KorisnikService(IKorisnikRepository korisnikGenericReporsitory)
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

        public Task<IKorisnikDomainModel> Get(Guid Id)//nije async
        {
            return KorisnikGenericReporsitory.GetAsync(Id);
        }

        public Task<IEnumerable<IKorisnikDomainModel>> GetAll()//nije async
        {
            return KorisnikGenericReporsitory.GetAllAsync();   
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
