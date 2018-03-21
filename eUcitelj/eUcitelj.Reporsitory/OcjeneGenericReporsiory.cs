using AutoMapper;
using eUcitelj.DAL.Models;
using eUcitelj.Model.Common;
using eUcitelj.Reporsitory.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class OcjeneGenericReporsiory : IOcjeneGenericReporsitory
    {
        protected IReporsitory Reporsitory { get; set; }
        public OcjeneGenericReporsiory(IReporsitory reporsitory)
        {
            this.Reporsitory = reporsitory;
        }
        public async Task<int> AddAsync(IOcjeneDomainModel addObj)
        {
            return await Reporsitory.AddAsync(Mapper.Map<Ocjene>(addObj));
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await Reporsitory.DeleteAsync<Ocjene>(Id);
        }

        public async Task<IEnumerable<IOcjeneDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IOcjeneDomainModel>>(await Reporsitory.GetAllAsync<Ocjene>());
        }

        public async Task<IOcjeneDomainModel> GetAsync(Guid Id)
        {
            return Mapper.Map<IOcjeneDomainModel>(await Reporsitory.GetAsync<Ocjene>(Id));
        }

        public async Task<int> UpdateAsync(IOcjeneDomainModel updated)
        {
            return await Reporsitory.UpdateAsync(Mapper.Map<Ocjene>(updated));
        }
    }
}
