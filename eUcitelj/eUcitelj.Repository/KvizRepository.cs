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
    public class KvizRepository : IKvizRepository
    {
        protected IGenericRepository Reporsitory { get; set; }
        public KvizRepository (IGenericRepository reporsitory)
        {
            this.Reporsitory = reporsitory;
        }
        public async Task<int> AddAsync(IKvizDomainModel addObj)
        {
            return await Reporsitory.AddAsync(Mapper.Map<Kviz>(addObj));
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await Reporsitory.DeleteAsync<Kviz>(Id);
        }

        public async Task<IEnumerable<IKvizDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IKvizDomainModel>>(await Reporsitory.GetAllAsync<Kviz>());
        }

        public async Task<IKvizDomainModel> GetAsync(Guid Id)
        {
            return Mapper.Map<IKvizDomainModel>(await Reporsitory.GetAsync<Kviz>(Id));            
        }

        public async Task<int> UpdateAsync(IKvizDomainModel updated)
        {
            return await Reporsitory.UpdateAsync<Kviz>(Mapper.Map<Kviz>(updated));
        }
    }
}
