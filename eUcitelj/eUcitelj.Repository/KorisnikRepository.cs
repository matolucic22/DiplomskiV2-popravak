using AutoMapper;
using eUcitelj.DAL;
using eUcitelj.DAL.Models;
using eUcitelj.Model;
using eUcitelj.Model.Common;
using eUcitelj.Reporsitory.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class KorisnikRepository : IKorisnikRepository
    {
        protected IGenericRepository Reporsitory { get; set; }
        public KorisnikRepository(IGenericRepository reporsitory)
        {
            this.Reporsitory = reporsitory;
        }
        public async Task<int> AddAsync(IKorisnikDomainModel addObj)
        {
            return await Reporsitory.AddAsync(Mapper.Map<Korisnik>(addObj));           
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await Reporsitory.DeleteAsync<Korisnik>(Id);
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IKorisnikDomainModel>>(await Reporsitory.GetAllAsync<Korisnik>());  
        }

        public async Task<IKorisnikDomainModel> GetAsync(Guid Id)
        {
            return Mapper.Map<IKorisnikDomainModel>(await Reporsitory.GetAsync<Korisnik>(Id));
        }

        public async Task<int> UpdateAsync(IKorisnikDomainModel updated)
        {
            return await Reporsitory.UpdateAsync(Mapper.Map<Korisnik>(updated));
        }

        public async Task<IKorisnikDomainModel> GetByUsernameAsync(string korisnicko_ime)
        {
            try
            {
                return Mapper.Map<IKorisnikDomainModel>(await Reporsitory.GetQueryable<Korisnik>().Where
                    (i => i.Korisnicko_ime == korisnicko_ime).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetAllKorisnicko_imeAsync()
        {
            try {

                var response = await Reporsitory.GetQueryable<Korisnik>().ToListAsync();
                var names= response.Select(a => new Korisnik { Korisnicko_ime = a.Korisnicko_ime }).ToList();
                return Mapper.Map<IEnumerable<IKorisnikDomainModel>>(names);

            } catch (Exception ex) {

                throw ex;
            }
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetAllKorisnikIdAsync()//Ova metoda dohvaca sve korisnike kojima je uloga (Rola) u sustavu "ucenik". Korištena je prilikom odobravanje uloge "roditelj", da bi se roditelju dodijelio ID ucenika kojem je roditelj i na taj nacin je omogucen pristup ocjenama samo onog ucenika kojem je roditelj.
        {
            try
            {
                var response = await Reporsitory.GetQueryable<Korisnik>().ToListAsync();
                var Ids = response.Select(a => new Korisnik { KorisnikId = a.KorisnikId, Uloga = a.Uloga }).Where(a => a.Uloga == "ucenik").ToList();
                return Mapper.Map<IEnumerable<IKorisnikDomainModel>>(Ids);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
