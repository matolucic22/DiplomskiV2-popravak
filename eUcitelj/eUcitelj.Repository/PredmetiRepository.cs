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
    public class PredmetiRepository : IPredmetiRepository
    {
       protected IGenericRepository Reporsitory{ get; set;}
       public PredmetiRepository(IGenericRepository reporsitory)
        {
            this.Reporsitory = reporsitory;
        }

        public async Task<int> AddAsync(IPredmetiDomainModel addObj)
        {
            try
            {
                return await Reporsitory.AddAsync(Mapper.Map<Predmet>(addObj));
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
                return await Reporsitory.DeleteAsync<Predmet>(Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<IPredmetiDomainModel>> GetAllAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<IPredmetiDomainModel>>(await Reporsitory.GetAllAsync<Predmet>());
            }catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<IPredmetiDomainModel> GetAsync(Guid Id)
        {
            try
            {
                return Mapper.Map<IPredmetiDomainModel>(await Reporsitory.GetAsync<Predmet>(Id));

            }catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<int> UpdateAsync(IPredmetiDomainModel updated)
        {
            try
            {
                return await Reporsitory.UpdateAsync(Mapper.Map<Predmet>(updated));
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
