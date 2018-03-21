﻿using eUcitelj.Model.Common;
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
        protected IOcjeneGenericReporsitory OcjeneGenericReporsitory;
        public OcjeneService(IOcjeneGenericReporsitory ocjeneGenericReporsitory)
        {
            this.OcjeneGenericReporsitory = ocjeneGenericReporsitory;
        }

        public async Task<int> Add(IOcjeneDomainModel addObj)
        {
            return await OcjeneGenericReporsitory.AddAsync(addObj);
        }

        public async Task<int> Delete(Guid Id)
        {
            return await OcjeneGenericReporsitory.DeleteAsync(Id);
        }

        public async Task<IOcjeneDomainModel> Get(Guid Id)
        {
            return await OcjeneGenericReporsitory.GetAsync(Id);
        }

        public async Task<IEnumerable<IOcjeneDomainModel>> GetAll()
        {
            return await OcjeneGenericReporsitory.GetAllAsync();
        }

        public async Task<int> Update(IOcjeneDomainModel updated)
        {
            return await OcjeneGenericReporsitory.UpdateAsync(updated);
        }
    }
}
