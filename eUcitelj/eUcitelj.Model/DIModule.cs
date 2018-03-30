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
            Bind<IUceniciDomainModel>().To<UceniciDomainModel>();
            Bind<IPredmetiDomainModel>().To<PredmetiDomainModel>();
            Bind<IOcjeneDomainModel>().To<OcjeneDomanModel>();
            Bind<IKvizDomainModel>().To<KvizDomainModel>();
        }
    }
}
