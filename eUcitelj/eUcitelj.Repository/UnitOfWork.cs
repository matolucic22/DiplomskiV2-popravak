using eUcitelj.DAL;
using eUcitelj.Reporsitory.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class UnitOfWork : IUnitOfWork
    {
        private eUciteljContext _context;
        private bool disposing;

        public UnitOfWork(eUciteljContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposed)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }



        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
