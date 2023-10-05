using AutoMapper;
using ProfileApp.Dto.TblStatusDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Mappings.AutoMapper
{
    public class TblStatusProfile : Profile
    {
        public TblStatusProfile()
        {
            CreateMap<TblStatus,TblStatusCreateDto>().ReverseMap();
            CreateMap<TblStatus,TblStatusListDto>().ReverseMap();
            CreateMap<TblStatus,TblStatusUpdateDto>().ReverseMap();
        }
    }
}
