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
            try
            {
                return await Reporsitory.AddAsync(Mapper.Map<Ocjene>(addObj));
            }
            catch (Exception e)
            {
                throw e;
            }           
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            try
            {
                return await Reporsitory.DeleteAsync<Ocjene>(Id);
            }
            catch (Exception e)
            {
                throw e;
            }      
        }

        public async Task<IEnumerable<IOcjeneDomainModel>> GetAllAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<IOcjeneDomainModel>>(await Reporsitory.GetAllAsync<Ocjene>());
            }
            catch (Exception e)
            {
                throw e;
            }        
        }

        public async Task<IOcjeneDomainModel> GetAsync(Guid Id)
        {
            try
            {
                return Mapper.Map<IOcjeneDomainModel>(await Reporsitory.GetAsync<Ocjene>(Id));
            }
            catch (Exception e)
            {
                throw e;
            }          
        }

        public async Task<int> UpdateAsync(IOcjeneDomainModel updated)
        {
            try
            {
                return await Reporsitory.UpdateAsync(Mapper.Map<Ocjene>(updated));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
