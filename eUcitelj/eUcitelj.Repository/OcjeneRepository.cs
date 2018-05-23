using AutoMapper;
using eUcitelj.DAL.Models;
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
    public class OcjeneRepository : IOcjeneRepository
    {
        protected IGenericRepository Reporsitory { get; set; }
        public OcjeneRepository(IGenericRepository reporsitory)
        {
            this.Reporsitory = reporsitory;
        }
        public async Task<int> AddAsync(IOcjeneDomainModel addObj)
        {
            return await Reporsitory.AddAsync(Mapper.Map<Ocjena>(addObj));
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await Reporsitory.DeleteAsync<Ocjena>(Id);
        }

        public async Task<IEnumerable<IOcjeneDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IOcjeneDomainModel>>(await Reporsitory.GetAllAsync<Ocjena>());
        }

        public async Task<IOcjeneDomainModel> GetAsync(Guid Id)
        {
            return Mapper.Map<IOcjeneDomainModel>(await Reporsitory.GetAsync<Ocjena>(Id)); 
        }

        public async Task<int> UpdateAsync(IOcjeneDomainModel updated)
        {
            return await Reporsitory.UpdateAsync(Mapper.Map<Ocjena>(updated));
        }

       
        public async Task<IEnumerable<IOcjeneDomainModel>> GetByKorisnikIdAsync(Guid KorisnikId)
        {
            try
            {
                return Mapper.Map<IEnumerable<IOcjeneDomainModel>>(await Reporsitory.GetQueryable<Ocjena>().Where
                    (i => i.KorisnikId == KorisnikId).ToListAsync());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
