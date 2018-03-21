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
   public class UceniciGenericReporsitory:IUceniciGenericReporsitory
    {
        protected IReporsitory Reporsitory { get; set; }
        public UceniciGenericReporsitory(IReporsitory reporsitory)
        {
            this.Reporsitory = reporsitory;
        }

        public async Task<int> AddAsync(IUceniciDomainModel addObj)
        {
            return await Reporsitory.AddAsync(Mapper.Map<Ucenici>(addObj));
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await Reporsitory.DeleteAsync<Ucenici>(Id);
        }

        public async Task<IEnumerable<IUceniciDomainModel>> GetAllAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<IUceniciDomainModel>>(await Reporsitory.GetAllAsync<Ucenici>());

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IUceniciDomainModel> GetAsync(Guid Id)
        {
            try
            {
                return Mapper.Map<IUceniciDomainModel>(await Reporsitory.GetAsync<Ucenici>(Id));

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> UpdateAsync(IUceniciDomainModel updated)
        {
            try
            {
                return await Reporsitory.UpdateAsync(Mapper.Map<Ucenici>(updated));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
