using AutoMapper;

namespace eUcitelj.MVC_WebApi.AutoMapperConf
{
    public class MapperInit
    {
        public static void Init()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(new[] {
                typeof(eUcitelj.MVC_WebApi.AutoMapperConf.MappingProfile),
                typeof(eUcitelj.DResolver.MappingConfig.MappingProfile)
               })
           );
        }
    }
}