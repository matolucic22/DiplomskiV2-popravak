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
            Bind<IReporsitory>().To<Reporsitory>();
            Bind<IKorisnikGenericReporsitory>().To<KorisnikGenericReporsitory>();
            Bind<IPredmetiGenericReporsitory>().To<PredmetiGenericReporsitory>();
            Bind<IOcjeneGenericReporsitory>().To<OcjeneGenericReporsiory>();
            Bind<IKvizGenericReporsitory>().To<KvizGenericReporsitory>();
            Bind<IUceniciGenericReporsitory>().To<UceniciGenericReporsitory>();
        }
    }
}
