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
        protected IPredmetKorisnikRepository PredmetKorisnikRepository { get; set; }

        public PredmetKorisnikService(IPredmetKorisnikRepository predmetKorisnikRepository)
        {
            this.PredmetKorisnikRepository = predmetKorisnikRepository;
        }

        public async Task<IEnumerable<IPredmetKorisnikDomainModel>> GetAllAsync()
        {
            return await PredmetKorisnikRepository.GetAllAsync();
        }

        public async Task<IPredmetKorisnikDomainModel> GetAsync(Guid Id)
        {
            return await PredmetKorisnikRepository.GetAsync(Id);
        }

        public async Task<int> AddAsync(IPredmetKorisnikDomainModel addObj)
        {
            addObj.PredmetKorisnikId = Guid.NewGuid();
            return await PredmetKorisnikRepository.AddAsync(addObj);
        }

        public async Task<int> UpdateAsync(IPredmetKorisnikDomainModel updated)
        {
            return await PredmetKorisnikRepository.UpdateAsync(updated);
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await PredmetKorisnikRepository.DeleteAsync(Id);
        }
    }
}
