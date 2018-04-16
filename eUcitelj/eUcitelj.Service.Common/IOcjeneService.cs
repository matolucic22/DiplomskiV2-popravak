﻿using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service.Common
{
    public interface IOcjeneService
    {
        Task<IEnumerable<IOcjeneDomainModel>> GetAllAsync();
        Task<IOcjeneDomainModel> GetAsync(Guid Id);
        Task<int> AddAsync(IOcjeneDomainModel addObj);
        Task<int> UpdateAsync(IOcjeneDomainModel updated);
        Task<int> DeleteAsync(Guid Id);
    }
}
