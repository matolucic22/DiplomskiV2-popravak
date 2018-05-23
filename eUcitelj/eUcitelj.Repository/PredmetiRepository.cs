using AutoMapper;
using eUcitelj.Common;
using eUcitelj.DAL.Models;
using eUcitelj.Model.Common;
using eUcitelj.Reporsitory.Common;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class PredmetiRepository : IPredmetiRepository
    {
       protected IGenericRepository Reporsitory{ get; set;}
       public PredmetiRepository(IGenericRepository reporsitory)
        {
            this.Reporsitory = reporsitory;
        }

        public async Task<int> AddAsync(IPredmetiDomainModel addObj)
        {
            return await Reporsitory.AddAsync(Mapper.Map<Predmet>(addObj));
        }

        public async Task<int> AddToBridgeAsync(IPredmetKorisnikDomainModel addObj)
        {
            return await Reporsitory.AddAsync(Mapper.Map<PredmetKorisnik>(addObj));
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await Reporsitory.DeleteAsync<Predmet>(Id);
        }

        public async Task<IEnumerable<IPredmetiDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IPredmetiDomainModel>>(await Reporsitory.GetAllAsync<Predmet>());
        }

        public async Task<IPredmetiDomainModel> GetAsync(Guid Id)
        {
            return Mapper.Map<IPredmetiDomainModel>(await Reporsitory.GetAsync<Predmet>(Id));
        }

        public async Task<int> UpdateAsync(IPredmetiDomainModel updated)
        {
            return await Reporsitory.UpdateAsync(Mapper.Map<Predmet>(updated));
        }

        public async Task<IPagedList<IPredmetiDomainModel>> SortingPagingFilteringAsync(FilterModel filterModel)
        {
            IEnumerable <IPredmetiDomainModel> predmeti;
            if(String.IsNullOrWhiteSpace(filterModel.TrazeniPojam) || filterModel.TrazeniPojam == "undefined")
            {
                predmeti = Mapper.Map<IEnumerable<IPredmetiDomainModel>>(await Reporsitory.GetAllAsync<Predmet>());
            }
            else
            {
                predmeti=Mapper.Map<IEnumerable<IPredmetiDomainModel>>(await Reporsitory.GetAllAsync<Predmet>()).Where(p => p.Ime_predmeta.Contains(filterModel.TrazeniPojam));
                
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
            return predmeti.ToPagedList(filterModel.BrStr ?? 1, 4);//1. broj trenutne stranice (indeks podskupa); 2. velicina stranice(maksimalni broj elemenata na stranici-->maksimalna velicina podskupa)
            //brStr ?? 1 --> ako je brStr null, stavi da bude 1. int?-->omogucava da bude var null.
        }
    }
}
