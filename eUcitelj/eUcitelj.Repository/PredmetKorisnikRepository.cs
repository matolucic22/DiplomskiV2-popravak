using AutoMapper;
using eUcitelj.DAL.Models;
using eUcitelj.Model;
using eUcitelj.Model.Common;
using eUcitelj.Reporsitory.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class PredmetKorisnikRepository:IPredmetKorisnikRepository
    {
        protected IGenericRepository Reporsitory { get; set; }
        public PredmetKorisnikRepository(IGenericRepository reporsitory)
        {
            this.Reporsitory = reporsitory;
        }
        public async Task<int> AddAsync(IPredmetKorisnikDomainModel addObj)
        {
            return await Reporsitory.AddAsync(Mapper.Map<PredmetKorisnik>(addObj));
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await Reporsitory.DeleteAsync<PredmetKorisnik>(Id);
        }

        public async Task<IEnumerable<IPredmetKorisnikDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IPredmetKorisnikDomainModel>>(await Reporsitory.GetAllAsync<PredmetKorisnik>());
        }

        public async Task<IPredmetKorisnikDomainModel> GetAsync(Guid Id)
        {
            return Mapper.Map<IPredmetKorisnikDomainModel>(await Reporsitory.GetAsync<PredmetKorisnik>(Id));
        }

        public async Task<int> UpdateAsync(IPredmetKorisnikDomainModel updated)
        {
            return await Reporsitory.UpdateAsync(Mapper.Map<PredmetKorisnik>(updated));
        }
    }
}
