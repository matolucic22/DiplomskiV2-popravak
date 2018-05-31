using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory.Common
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> Save();
        void Dispose(bool disposed);
    }
}
