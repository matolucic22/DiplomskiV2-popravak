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
            return await Reporsitory.AddAsync(Mapper.Map<Ucenik>(addObj));
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await Reporsitory.DeleteAsync<Ucenik>(Id);
        }

        public async Task<IEnumerable<IUceniciDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IUceniciDomainModel>>(await Reporsitory.GetAllAsync<Ucenik>());
        }

        public async Task<IUceniciDomainModel> GetAsync(Guid Id)
        {
            return Mapper.Map<IUceniciDomainModel>(await Reporsitory.GetAsync<Ucenik>(Id));
        }

        public async Task<int> UpdateAsync(IUceniciDomainModel updated)
        {
            return await Reporsitory.UpdateAsync(Mapper.Map<Ucenik>(updated));
        }
    }
}
