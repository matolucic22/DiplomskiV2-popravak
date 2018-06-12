using AutoMapper;
using eUcitelj.DAL.Models;
using eUcitelj.Model;
using eUcitelj.Model.Common;
using eUcitelj.Reporsitory.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class PredmetKorisnikRepository:IPredmetKorisnikRepository
    {
        private UnitOfWork unitOfWork;
        public PredmetKorisnikRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> AddAsync(IPredmetKorisnikDomainModel addObj)
        {
            return await unitOfWork.PredmetKorisnikRepository.AddAsync(Mapper.Map<PredmetKorisnik>(addObj));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await unitOfWork.PredmetKorisnikRepository.DeleteAsync<PredmetKorisnik>(id);
        }

        public async Task<IEnumerable<IPredmetKorisnikDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IPredmetKorisnikDomainModel>>(await unitOfWork.PredmetKorisnikRepository.GetAllAsync<PredmetKorisnik>());
        }

        public async Task<IPredmetKorisnikDomainModel> GetAsync(Guid id)
        {
            return Mapper.Map<IPredmetKorisnikDomainModel>(await unitOfWork.PredmetKorisnikRepository.GetAsync<PredmetKorisnik>(id));
        }

        public async Task<int> UpdateAsync(IPredmetKorisnikDomainModel updated)
        {
            return await unitOfWork.PredmetKorisnikRepository.UpdateAsync(Mapper.Map<PredmetKorisnik>(updated));
        }
    }
}
