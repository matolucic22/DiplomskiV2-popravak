using AutoMapper;
using eUcitelj.DAL.Common;
using eUcitelj.DAL.Models;
using eUcitelj.Model;
using eUcitelj.Model.Common;
using eUcitelj.MVC_WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUcitelj.MVC_WebApi.AutoMapperConf
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {      
            //Domain to View
            CreateMap<KorisnikDomainModel, KorisnikViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //Interface(Domain)-Domain
            CreateMap<KorisnikDomainModel, IKorisnikDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //Interface(Domain)-View
            CreateMap<IKorisnikDomainModel, KorisnikViewModel>().PreserveReferences().ReverseMap().PreserveReferences();


            //Domain to View
            CreateMap<PredmetiDomainModel, PredmetiViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //Interface(Domain)-Domain
            CreateMap<PredmetiDomainModel, IPredmetiDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //Interface(Domain)-View
            CreateMap<IPredmetiDomainModel, PredmetiViewModel>().PreserveReferences().ReverseMap().PreserveReferences();


            //Domain to View
            CreateMap<OcjeneDomanModel, OcjeneViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //Interface(Domain)-Domain
            CreateMap<OcjeneDomanModel, IOcjeneDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //Interface(Domain)-View
            CreateMap<IOcjeneDomainModel, OcjeneViewModel>().PreserveReferences().ReverseMap().PreserveReferences();


            //Domain to View
            CreateMap<KvizDomainModel, KvizViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //Interface(Domain)-Domain
            CreateMap<KvizDomainModel, IKvizDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //Interface(Domain)-View
            CreateMap<IKvizDomainModel, KvizViewModel>().PreserveReferences().ReverseMap().PreserveReferences();


            //Domain to View
            CreateMap<UceniciDomainModel, UceniciViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //Interface(Domain)-Domain
            CreateMap<UceniciDomainModel, IUceniciDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //Interface(Domain)-View
            CreateMap<IUceniciDomainModel, UceniciViewModel>().PreserveReferences().ReverseMap().PreserveReferences();



            CreateMap<Predmeti, PredmetiViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
            CreateMap<IPredmeti, PredmetiViewModel>().PreserveReferences().ReverseMap().PreserveReferences();

            CreateMap<Korisnik, KorisnikViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
            CreateMap<IKorisnik, KorisnikViewModel>().PreserveReferences().ReverseMap().PreserveReferences();

            CreateMap<Ocjene, OcjeneViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
            CreateMap<IOcjene, OcjeneViewModel>().PreserveReferences().ReverseMap().PreserveReferences();

            CreateMap<Kviz, KvizViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
            CreateMap<IKviz, KvizViewModel>().PreserveReferences().ReverseMap().PreserveReferences();

            CreateMap<Ucenici, UceniciViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
            CreateMap<IUcenici, UceniciViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
        }
    }
}