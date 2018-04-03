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
            try
            {
                return await Reporsitory.AddAsync(Mapper.Map<Kviz>(addObj));
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
                return await Reporsitory.DeleteAsync<Kviz>(Id);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task<IEnumerable<IKvizDomainModel>> GetAllAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<IKvizDomainModel>>(await Reporsitory.GetAllAsync<Kviz>());
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task<IKvizDomainModel> GetAsync(Guid Id)
        {
            try
            {
                return Mapper.Map<IKvizDomainModel>(await Reporsitory.GetAsync<Kviz>(Id));
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task<int> UpdateAsync(IKvizDomainModel updated)
        {
            try
            {
                return await Reporsitory.UpdateAsync<Kviz>(Mapper.Map<Kviz>(updated));
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
