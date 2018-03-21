using eUcitelj.DAL;
using eUcitelj.DAL.Common;
using eUcitelj.Reporsitory;
using eUcitelj.Reporsitory.Common;
using eUcitelj.Service;
using eUcitelj.Service.Common;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DResolver.NinjectConfig
{
    public class Resolver:NinjectModule
    {
        public override void Load()
        {
            Bind<IeUciteljContext>().To<eUciteljContext>();
            
            Bind<IReporsitory>().To<Reporsitory.Reporsitory>();
            Bind<IKorisnikGenericReporsitory>().To<KorisnikGenericReporsitory>();
            Bind<IPredmetiGenericReporsitory>().To<PredmetiGenericReporsitory>();
            Bind<IOcjeneGenericReporsitory>().To<OcjeneGenericReporsiory>();
            Bind<IKvizGenericReporsitory>().To<KvizGenericReporsitory>();
            Bind<IUceniciGenericReporsitory>().To<UceniciGenericReporsitory>();

            Bind<IKorisnikService>().To<KorisnikService>();
            Bind<IPredmetiService>().To<PredmetiService>();
            Bind<IOcjeneService>().To<OcjeneService>();
            Bind<IKvizService>().To<KvizService>();
            Bind<IUceniciService>().To<UceniciService>();
        }
    }
}
