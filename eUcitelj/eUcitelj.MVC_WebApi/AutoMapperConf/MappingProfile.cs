using AutoMapper;
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
            //Interface(Domain)-View
            CreateMap<IKorisnikDomainModel, KorisnikViewModel>().PreserveReferences().ReverseMap().PreserveReferences();


            //Interface(Domain)-View
            CreateMap<IPredmetDomainModel, PredmetViewModel>().PreserveReferences().ReverseMap().PreserveReferences();

            
            //Interface(Domain)-View
            CreateMap<IOcjeneDomainModel, OcjenaViewModel>().PreserveReferences().ReverseMap().PreserveReferences();

            
            //Interface(Domain)-View
            CreateMap<IKvizDomainModel, KvizViewModel>().PreserveReferences().ReverseMap().PreserveReferences();

            
            //Interface(Domain)-View
            CreateMap<IUceniciDomainModel, UcenikViewModel>().PreserveReferences().ReverseMap().PreserveReferences();

            //Interface(Domain)-View
            CreateMap<IPredmetKorisnikDomainModel, PredmetKorisnikViewModel>().PreserveReferences().ReverseMap().PreserveReferences();
        }
    }
}