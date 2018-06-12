using eUcitelj.Model.Common;
using eUcitelj.Reporsitory.Common;
using eUcitelj.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service
{
     public class PredmetKorisnikService:IPredmetKorisnikService
    {
        private IPredmetKorisnikRepository predmetKorisnikRepository;

        public PredmetKorisnikService(IPredmetKorisnikRepository predmetKorisnikRepository)
        {
            this.predmetKorisnikRepository = predmetKorisnikRepository;
        }

        public async Task<IEnumerable<IPredmetKorisnikDomainModel>> GetAllAsync()
        {
            return await predmetKorisnikRepository.GetAllAsync();
        }

        public async Task<IPredmetKorisnikDomainModel> GetAsync(Guid id)
        {
            return await predmetKorisnikRepository.GetAsync(id);
        }

        public async Task<int> AddAsync(IPredmetKorisnikDomainModel addObj)
        {
            addObj.PredmetKorisnikId = Guid.NewGuid();
            return await predmetKorisnikRepository.AddAsync(addObj);
        }

        public async Task<int> UpdateAsync(IPredmetKorisnikDomainModel updated)
        {
            return await predmetKorisnikRepository.UpdateAsync(updated);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await predmetKorisnikRepository.DeleteAsync(id);
        }
    }
}
