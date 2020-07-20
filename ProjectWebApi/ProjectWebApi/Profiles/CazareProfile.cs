using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Profiles
{
    public class CazareProfile : Profile
    {

        public CazareProfile()
        {

            CreateMap<Entities.Cazare, ExternalModels.CazareDTO>();
            CreateMap<ExternalModels.CazareDTO, Entities.Cazare>();

            CreateMap<Entities.Oras, ExternalModels.OrasDTO>();
            CreateMap<ExternalModels.OrasDTO, Entities.Oras>();


        }
    }
}
