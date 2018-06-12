using AutoMapper;
using eUcitelj.DAL.Models;
using eUcitelj.Model.Common;
using eUcitelj.Reporsitory.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class OcjeneRepository : IOcjeneRepository
    {
        private UnitOfWork unitOfWork;
        public OcjeneRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> AddAsync(IOcjeneDomainModel addObj)
        {
            return await unitOfWork.OcjeneRepository.AddAsync(Mapper.Map<Ocjena>(addObj));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await unitOfWork.OcjeneRepository.DeleteAsync<Ocjena>(id);
        }

        public async Task<IEnumerable<IOcjeneDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IOcjeneDomainModel>>(await unitOfWork.OcjeneRepository.GetAllAsync<Ocjena>());
        }

        public async Task<IOcjeneDomainModel> GetAsync(Guid id)
        {
            return Mapper.Map<IOcjeneDomainModel>(await unitOfWork.OcjeneRepository.GetAsync<Ocjena>(id)); 
        }

        public async Task<int> UpdateAsync(IOcjeneDomainModel updated)
        {
            return await unitOfWork.OcjeneRepository.UpdateAsync(Mapper.Map<Ocjena>(updated));
        }

       
        public async Task<IEnumerable<IOcjeneDomainModel>> GetByKorisnikIdAsync(Guid korisnikId)
        {
            try
            {
                return Mapper.Map<IEnumerable<IOcjeneDomainModel>>(await unitOfWork.OcjeneRepository.GetQueryable<Ocjena>().Where
                    (i => i.KorisnikId == korisnikId).ToListAsync());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
