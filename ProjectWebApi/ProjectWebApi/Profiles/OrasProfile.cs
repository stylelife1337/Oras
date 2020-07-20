using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Profiles
{
    public class OrasProfile : Profile
    {
        public OrasProfile()
        {
            CreateMap<Entities.Oras, ExternalModels.OrasDTO>();
            CreateMap<ExternalModels.OrasDTO, Entities.Oras>();

            CreateMap<Entities.Tara, ExternalModels.TaraDTO>();
            CreateMap<ExternalModels.TaraDTO, Entities.Tara>();
        }
    }
}
