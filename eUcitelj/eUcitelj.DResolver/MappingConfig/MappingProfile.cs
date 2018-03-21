using AutoMapper;
using eUcitelj.DAL.Common;
using eUcitelj.DAL.Models;
using eUcitelj.Model;
using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DResolver.MappingConfig
{
   public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //POCO to Domain
            CreateMap<Korisnik, KorisnikDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //POCO to IDomain
            CreateMap<Korisnik, IKorisnikDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //POCO to IPOCO
            CreateMap<Korisnik, IKorisnik>().PreserveReferences().ReverseMap().PreserveReferences();



            //POCO to Domain
            CreateMap<Predmeti, PredmetiDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //POCO to IDomain
            CreateMap<Predmeti, IPredmetiDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //POCO to IPOCO
            CreateMap<Predmeti, IPredmeti>().PreserveReferences().ReverseMap().PreserveReferences();


            //POCO to Domain
            CreateMap<Ocjene, OcjeneDomanModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //POCO to IDomain
            CreateMap<Ocjene, IOcjeneDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //POCO to IPOCO
            CreateMap<Ocjene, IOcjene>().PreserveReferences().ReverseMap().PreserveReferences();


            //POCO to Domain
            CreateMap<Kviz, KvizDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //POCO to IDomain
            CreateMap<Kviz, IKvizDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //POCO to IPOCO
            CreateMap<Kviz, IKviz>().PreserveReferences().ReverseMap().PreserveReferences();


            //POCO to Domain
            CreateMap<Ucenici, UceniciDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //POCO to IDomain
            CreateMap<Ucenici, IUceniciDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
            //POCO to IPOCO
            CreateMap<Ucenici, IUcenici>().PreserveReferences().ReverseMap().PreserveReferences();


        }
    }
}
