using AutoMapper;
using eUcitelj.DAL.Models;
using eUcitelj.Reporsitory.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class OcjeneGenericReporsitory : IOcjeneGenericReporsitory
    {
        protected IReporsitory Reporsitory { get; set; }
        OcjeneGenericReporsitory(IReporsitory reporsitory)
        {
            this.Reporsitory = reporsitory;
        }
        public async Task<int> AddAsync<IOcjeneDomainModel>(IOcjeneDomainModel addObj)
        {
            return await Reporsitory.AddAsync(Mapper.Map<Ocjene>(addObj));
        }

        public async Task<int> DeleteAsync<IOcjeneDomainModel>(Guid Id)
        {
            return await Reporsitory.DeleteAsync<Ocjene>(Id);
        }

        public async Task<IEnumerable<IOcjeneDomainModel>> GetAllAsync<IOcjeneDomainModel>()
        {
            return Mapper.Map<IEnumerable<IOcjeneDomainModel>>(await Reporsitory.GetAllAsync<Kviz>());
        }

        public async Task<IOcjeneDomainModel> GetAsync<IOcjeneDomainModel>(Guid Id)
        {
            return Mapper.Map<IOcjeneDomainModel>(await Reporsitory.GetAsync<Ocjene>(Id));
        }

        public async Task<int> UpdateAsync<IOcjeneDomainModel>(IOcjeneDomainModel updated)
        {
            return await Reporsitory.UpdateAsync<Ocjene>(Mapper.Map<Ocjene>(updated));
        }
    }
}
