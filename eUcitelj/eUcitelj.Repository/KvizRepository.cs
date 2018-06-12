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
        private UnitOfWork unitOfWork;
        public KvizRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> AddAsync(IKvizDomainModel addObj)
        {
            return await unitOfWork.KvizRepository.AddAsync(Mapper.Map<Kviz>(addObj));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await unitOfWork.KvizRepository.DeleteAsync<Kviz>(id);
        }

        public async Task<IEnumerable<IKvizDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IKvizDomainModel>>(await unitOfWork.KvizRepository.GetAllAsync<Kviz>());
        }

        public async Task<IKvizDomainModel> GetAsync(Guid id)
        {
            return Mapper.Map<IKvizDomainModel>(await unitOfWork.KvizRepository.GetAsync<Kviz>(id));            
        }

        public async Task<int> UpdateAsync(IKvizDomainModel updated)
        {
            return await unitOfWork.KvizRepository.UpdateAsync<Kviz>(Mapper.Map<Kviz>(updated));
        }
    }
}
