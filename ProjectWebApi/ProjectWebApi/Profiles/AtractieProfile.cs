using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Profiles
{
    public class AtractieProfile : Profile
    {
        public AtractieProfile()
        {
            CreateMap<Entities.Atractie, ExternalModels.AtractieDTO>();
            CreateMap<ExternalModels.AtractieDTO, Entities.Atractie>();

            CreateMap<Entities.Oras, ExternalModels.OrasDTO>();
            CreateMap<ExternalModels.OrasDTO, Entities.Oras>();
        }
    }

}
