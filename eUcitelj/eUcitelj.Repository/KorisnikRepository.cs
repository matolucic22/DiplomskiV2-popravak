﻿using AutoMapper;
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
            try
            {

                var response = await Reporsitory.GetQueryable<Korisnik>().ToListAsync();
                var names = response.Select(a => new Korisnik { Korisnicko_ime = a.Korisnicko_ime }).ToList();
                return Mapper.Map<IEnumerable<IKorisnikDomainModel>>(names);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetAllUcenikAsync()//Ova metoda dohvaca sve korisnike kojima je uloga (Rola) u sustavu "ucenik". Koristena je za dohvacanje i prikaz svih ucenika u sustavu.
        {
            try
            {
                var response = await Reporsitory.GetQueryable<Korisnik>().ToListAsync();
                var Ids =  response.Select(a => new Korisnik { Id = a.Id, Ime_korisnika = a.Ime_korisnika, Prezime_korisnika = a.Prezime_korisnika, Korisnicko_ime = a.Korisnicko_ime, Uloga = a.Uloga }).Where(a => a.Uloga == "ucenik").ToList();
                return Mapper.Map<IEnumerable<IKorisnikDomainModel>>(Ids);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetNepotvrdenoAsync()//Ova metoda dohvaca sve korisnike kojima je potvrda u sustavu "???". Koristena je za dohvacanje i prikaz svih ucenika u sustavu sa takvom potvrdom.
        {
            try
            {
                var response = await Reporsitory.GetQueryable<Korisnik>().ToListAsync();
                var Ids = response.Select(a => new Korisnik { Id = a.Id, Ime_korisnika = a.Ime_korisnika, Prezime_korisnika = a.Prezime_korisnika, Korisnicko_ime = a.Korisnicko_ime, Uloga = a.Uloga, Potvrda=a.Potvrda }).Where(a => a.Potvrda == "???").ToList();
                return Mapper.Map<IEnumerable<IKorisnikDomainModel>>(Ids);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetPotvrdenoAsync()//Ova metoda dohvaca sve korisnike kojima je potvrda u sustavu "Da". Koristena je za dohvacanje i prikaz svih ucenika u sustavu sa takvom potvrdom.
        {
            try
            {
                var response = await Reporsitory.GetQueryable<Korisnik>().ToListAsync();
                var Ids = response.Select(a => new Korisnik { Id = a.Id, Ime_korisnika = a.Ime_korisnika, Prezime_korisnika = a.Prezime_korisnika, Korisnicko_ime = a.Korisnicko_ime, Uloga = a.Uloga, Potvrda = a.Potvrda }).Where(a => a.Potvrda == "Da").ToList();
                return Mapper.Map<IEnumerable<IKorisnikDomainModel>>(Ids);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IKorisnikDomainModel>> GetOdbijenoAsync()//Ova metoda dohvaca sve korisnike kojima je potvrda u sustavu "Ne". Koristena je za dohvacanje i prikaz svih ucenika u sustavu sa takvom potvrdom.
        {
            try
            {
                var response = await Reporsitory.GetQueryable<Korisnik>().ToListAsync();
                var Ids = response.Select(a => new Korisnik { Id = a.Id, Ime_korisnika = a.Ime_korisnika, Prezime_korisnika = a.Prezime_korisnika, Korisnicko_ime = a.Korisnicko_ime, Uloga = a.Uloga, Potvrda = a.Potvrda }).Where(a => a.Potvrda == "Ne").ToList();
                return Mapper.Map<IEnumerable<IKorisnikDomainModel>>(Ids);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
