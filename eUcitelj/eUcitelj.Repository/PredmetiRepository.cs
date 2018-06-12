using AutoMapper;
using eUcitelj.Common;
using eUcitelj.DAL.Models;
using eUcitelj.Model.Common;
using eUcitelj.Reporsitory.Common;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class PredmetiRepository : IPredmetiRepository
    {
        private UnitOfWork unitOfWork;
        public PredmetiRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(IPredmetDomainModel addObj)
        {
            return await unitOfWork.PredmetiRepository.AddAsync(Mapper.Map<Predmet>(addObj));
        }

        public async Task<int> AddToBridgeAsync(IPredmetKorisnikDomainModel addObj)
        {
            return await unitOfWork.PredmetiRepository.AddAsync(Mapper.Map<PredmetKorisnik>(addObj));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await unitOfWork.PredmetiRepository.DeleteAsync<Predmet>(id);
        }

        public async Task<IPredmetDomainModel> GetAsync(Guid id)
        {
            return Mapper.Map<IPredmetDomainModel>(await unitOfWork.PredmetiRepository.GetAsync<Predmet>(id));
        }

        public async Task<int> UpdateAsync(IPredmetDomainModel updated)
        {
            return await unitOfWork.PredmetiRepository.UpdateAsync(Mapper.Map<Predmet>(updated));
        }

        public async Task<IPagedList<IPredmetDomainModel>> FindPredmetiAsync(FilterModel filterModel)
        {
            IEnumerable <IPredmetDomainModel> predmeti;
            if(String.IsNullOrWhiteSpace(filterModel.TrazeniPojam) || filterModel.TrazeniPojam == "undefined")
            {
                predmeti = Mapper.Map<IEnumerable<IPredmetDomainModel>>(await unitOfWork.PredmetiRepository.GetAllAsync<Predmet>());
            }
            else
            {
                predmeti=Mapper.Map<IEnumerable<IPredmetDomainModel>>(await unitOfWork.PredmetiRepository.GetAllAsync<Predmet>()).Where(p => p.Ime_predmeta.Contains(filterModel.TrazeniPojam));
                
            }
            switch (filterModel.Redoslijed)
            {
                case "Ime_silazno":
                    predmeti = predmeti.OrderByDescending(p => p.Ime_predmeta);
                    break;
                default:
                    predmeti = predmeti.OrderBy(p => p.Ime_predmeta);
                    break;
            }
            return predmeti.ToPagedList(filterModel.BrStr ?? 1, filterModel.BrEl);//1. broj trenutne stranice (indeks podskupa); 2. velicina stranice(maksimalni broj elemenata na stranici-->maksimalna velicina podskupa)
            //brStr ?? 1 --> ako je brStr null, stavi da bude 1. int?-->omogucava da bude var null.
        }
        public async Task<IEnumerable<IPredmetDomainModel>> GetAllImePredmetaAsync()//Ova metoda dohvaca sve korisnike kojima je uloga (Rola) u sustavu "ucenik". Koristena je za dohvacanje i prikaz svih ucenika u sustavu.
        {
            try
            {
                var response = await unitOfWork.PredmetiRepository.GetQueryable<Predmet>().ToListAsync();
                var predmeti = response.Select(a => new Predmet { Ime_predmeta = a.Ime_predmeta}).ToList();
                return Mapper.Map<IEnumerable<IPredmetDomainModel>>(predmeti);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IPredmetDomainModel>> GetAllAsync() //funkciju nisam brisao zbog ostalih tablica (ocjene i kviz) - da ne idem u širinu nisam ništa mijenjao na njima.
        {
            return Mapper.Map<IEnumerable<IPredmetDomainModel>>(await unitOfWork.PredmetiRepository.GetAllAsync<Predmet>());
        }
    }
}
