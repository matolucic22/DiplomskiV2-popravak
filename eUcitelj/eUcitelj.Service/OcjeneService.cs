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
    public class OcjeneService:IOcjeneService
    {
        /* VAŠE PITANJE: 
         * public async Task<int> Add(IOcjeneDomainModel addObj) - ako je async metoda, sufix Async dodavati na svaku metodu(servisi)
         
           ODG.: Ja se ispričavam, ali nisam razumio što želite reći. Sve metode su u servisima asinkrone (osim onih što ste rekli da su nepotrebne u prijašnjim pitanjima). */
        private IOcjeneRepository ocjeneGenericReporsitory;
        public OcjeneService(IOcjeneRepository ocjeneGenericReporsitory)
        {
            this.ocjeneGenericReporsitory = ocjeneGenericReporsitory;
        }

        public async Task<int> AddAsync(IOcjeneDomainModel addObj)
        {
            addObj.OcjenaId = Guid.NewGuid();
            addObj.DatumUpisa = DateTime.Now.Date;
            return await ocjeneGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await ocjeneGenericReporsitory.DeleteAsync(id);
        }

        public async Task<IOcjeneDomainModel> GetAsync(Guid id)
        {
            return await ocjeneGenericReporsitory.GetAsync(id);
        }

        public async Task<IEnumerable<IOcjeneDomainModel>> GetAllAsync()
        {
            return await ocjeneGenericReporsitory.GetAllAsync();
        }

        public async Task<int> UpdateAsync(IOcjeneDomainModel updated)
        {
            return await ocjeneGenericReporsitory.UpdateAsync(updated);
        }

        public async Task<IEnumerable<IOcjeneDomainModel>> GetByKorisnikIdAsync(Guid korisnikId)
        {
            return await ocjeneGenericReporsitory.GetByKorisnikIdAsync(korisnikId);
        }
    }
}
