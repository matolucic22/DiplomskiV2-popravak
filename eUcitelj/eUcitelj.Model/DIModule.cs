using eUcitelj.Model.Common;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Model
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IKorisnikDomainModel>().To<KorisnikDomainModel>();
            Bind<IUceniciDomainModel>().To<UcenikDomainModel>();
            Bind<IPredmetDomainModel>().To<PredmetDomainModel>();
            Bind<IOcjeneDomainModel>().To<OcjenaDomanModel>();
            Bind<IKvizDomainModel>().To<KvizDomainModel>();
            Bind<IPredmetKorisnikDomainModel>().To<PredmetKorisnikDomainModel>();
        }
    }
}
