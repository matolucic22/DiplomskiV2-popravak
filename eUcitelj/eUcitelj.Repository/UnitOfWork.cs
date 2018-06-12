using eUcitelj.DAL;
using eUcitelj.Reporsitory.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUcitelj.DAL.Models;

namespace eUcitelj.Reporsitory
{
    public class UnitOfWork : IDisposable
    {
        private eUciteljContext context = new eUciteljContext();
        private IGenericRepository<Korisnik> korisnikRepository;
        private IGenericRepository<Predmet> predmetiRepository;
        private IGenericRepository<Ocjena> ocjeneRepository;
        private IGenericRepository<Kviz> kvizRepository;
        private IGenericRepository<PredmetKorisnik> predmetKorisnikRepository;
        private IGenericRepository<Ucenik> uceniciRepository;

        public IGenericRepository<Korisnik> KorisnikRepository
        {
            get
            {
                if (korisnikRepository == null)
                    korisnikRepository = new GenericRepository<Korisnik>(context);
                return korisnikRepository;
            }
        }

        public IGenericRepository<Predmet> PredmetiRepository
        {
            get
            {
                if (predmetiRepository == null)
                    predmetiRepository = new GenericRepository<Predmet>(context);
                return predmetiRepository;
            }
        }

        public IGenericRepository<Ocjena> OcjeneRepository
        {
            get
            {
                if (ocjeneRepository == null)
                    ocjeneRepository = new GenericRepository<Ocjena>(context);
                return ocjeneRepository;
            }
        }

        public IGenericRepository<Kviz> KvizRepository
        {
            get
            {
                if (kvizRepository == null)
                    kvizRepository = new GenericRepository<Kviz>(context);
                return kvizRepository;
            }
        }

        public IGenericRepository<PredmetKorisnik> PredmetKorisnikRepository
        {
            get
            {
                if (predmetKorisnikRepository == null)
                    predmetKorisnikRepository = new GenericRepository<PredmetKorisnik>(context);
                return predmetKorisnikRepository;
            }
        }

        public IGenericRepository<Ucenik> UceniciRepository
        {
            get
            {
                if (uceniciRepository == null)
                     uceniciRepository = new GenericRepository<Ucenik>(context);
                return uceniciRepository;
            }
        }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

