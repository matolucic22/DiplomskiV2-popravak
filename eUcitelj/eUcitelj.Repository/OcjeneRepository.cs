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
    public class OcjeneRepository : IOcjeneRepository
    {
        protected IGenericRepository Reporsitory { get; set; }
        public OcjeneRepository(IGenericRepository reporsitory)
        {
            this.Reporsitory = reporsitory;
        }
        public async Task<int> AddAsync(IOcjeneDomainModel addObj)
        {
            try
            {
                return await Reporsitory.AddAsync(Mapper.Map<Ocjena>(addObj));
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
                return await Reporsitory.DeleteAsync<Ocjena>(Id);
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
                return Mapper.Map<IEnumerable<IOcjeneDomainModel>>(await Reporsitory.GetAllAsync<Ocjena>());
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
                return Mapper.Map<IOcjeneDomainModel>(await Reporsitory.GetAsync<Ocjena>(Id));
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
                return await Reporsitory.UpdateAsync(Mapper.Map<Ocjena>(updated));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
