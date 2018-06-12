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
        private UnitOfWork unitOfWork;
        public UceniciRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(IUceniciDomainModel addObj)
        { 
            return await unitOfWork.UceniciRepository.AddAsync(Mapper.Map<Ucenik>(addObj));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await unitOfWork.UceniciRepository.DeleteAsync<Ucenik>(id);
        }

        public async Task<IEnumerable<IUceniciDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IUceniciDomainModel>>(await unitOfWork.UceniciRepository.GetAllAsync<Ucenik>());
        }

        public async Task<IUceniciDomainModel> GetAsync(Guid id)
        {
            return Mapper.Map<IUceniciDomainModel>(await unitOfWork.UceniciRepository.GetAsync<Ucenik>(id));
        }

        public async Task<int> UpdateAsync(IUceniciDomainModel updated)
        {
            return await unitOfWork.UceniciRepository.UpdateAsync(Mapper.Map<Ucenik>(updated));
        }
    }
}
