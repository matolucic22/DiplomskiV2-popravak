using eUcitelj.Service.Common;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IKorisnikService>().To<KorisnikService>();
            Bind<IPredmetiService>().To<PredmetiService>();
            Bind<IOcjeneService>().To<OcjeneService>();
            Bind<IKvizService>().To<KvizService>();
            Bind<IUceniciService>().To<UceniciService>();
            Bind<IPredmetKorisnikService>().To<PredmetKorisnikService>();

        }
    }
}
