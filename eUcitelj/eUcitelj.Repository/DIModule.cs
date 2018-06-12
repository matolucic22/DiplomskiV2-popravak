using eUcitelj.Reporsitory;
using eUcitelj.Reporsitory.Common;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            Bind<IKorisnikRepository>().To<KorisnikRepository>();
            Bind<IPredmetiRepository>().To<PredmetiRepository>();
            Bind<IOcjeneRepository>().To<OcjeneRepository>();
            Bind<IKvizRepository>().To<KvizRepository>();
            Bind<IUceniciRepository>().To<UceniciRepository>();
            Bind<IPredmetKorisnikRepository>().To<PredmetKorisnikRepository>();
        }
    }
}
