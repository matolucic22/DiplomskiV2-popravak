using AutoMapper;
using eUcitelj.DAL.Models;
using eUcitelj.Model;
using eUcitelj.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.Reporsitory
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            //entity-domainModel (interface)      
            CreateMap<Korisnik, IKorisnikDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();//dovoljno je mapirati samo entitet sa interfaceom modela. Bind interfacea i modela već postoji.

            
            CreateMap<Predmeti, IPredmetiDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();

            
            CreateMap<Ocjene, IOcjeneDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();

            
            CreateMap<Kviz, IKvizDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();

            
            CreateMap<Ucenici, IUceniciDomainModel>().PreserveReferences().ReverseMap().PreserveReferences();
        }
    }
}

