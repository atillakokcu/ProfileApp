using AutoMapper;
using ProfileApp.Dto.TblActivationDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Mappings.AutoMapper
{
    public class TblActivationProfile : Profile
    {
        public TblActivationProfile()
        {
            CreateMap<TblActivation, TblActivationCreateDto>().ReverseMap();
            CreateMap<TblActivation, TblActivationListDto>().ReverseMap();
            CreateMap<TblActivation, TblActivationUpdateDto>().ReverseMap();
        }
    }
}
