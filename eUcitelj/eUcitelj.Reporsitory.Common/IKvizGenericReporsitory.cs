﻿using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory.Common
{
    public interface IKvizGenericReporsitory
    {
        Task<IEnumerable<IKvizDomainModel>> GetAllAsync();//vraća IEnimerable polje podataka
        Task<IKvizDomainModel> GetAsync(Guid Id);
        Task<int> AddAsync(IKvizDomainModel addObj);
        Task<int> UpdateAsync(IKvizDomainModel updated);
        Task<int> DeleteAsync(Guid Id);
    }
}
