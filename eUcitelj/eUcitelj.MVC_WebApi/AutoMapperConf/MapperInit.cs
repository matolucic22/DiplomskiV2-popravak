using AutoMapper;

namespace eUcitelj.MVC_WebApi.AutoMapperConf
{
    public class MapperInit
    {
        public static void Init()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(new[] {
                typeof(MappingProfile),
                typeof(eUcitelj.Reporsitory.MappingProfile)
               })
           );
        }
    }
}