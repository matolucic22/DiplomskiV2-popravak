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
   public class UceniciRepository:IUceniciRepository
    {
        protected IGenericRepository Reporsitory { get; set; }
        public UceniciRepository(IGenericRepository reporsitory)
        {
            this.Reporsitory = reporsitory;
        }

        public async Task<int> AddAsync(IUceniciDomainModel addObj)
        {
            try
            {
                return await Reporsitory.AddAsync(Mapper.Map<Ucenik>(addObj));
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
                return await Reporsitory.DeleteAsync<Ucenik>(Id);
            }
            catch (Exception e)
            {
                throw e;
            }          
        }

        public async Task<IEnumerable<IUceniciDomainModel>> GetAllAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<IUceniciDomainModel>>(await Reporsitory.GetAllAsync<Ucenik>());

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
                return Mapper.Map<IUceniciDomainModel>(await Reporsitory.GetAsync<Ucenik>(Id));

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
                return await Reporsitory.UpdateAsync(Mapper.Map<Ucenik>(updated));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
