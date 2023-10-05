using AutoMapper;
using ProfileApp.Dto.TblUserDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Mappings.AutoMapper
{
    public class TblUserProfile : Profile
    {
        public TblUserProfile()
        {
            CreateMap<TblUser,TblUserCreateDto>().ReverseMap();
            CreateMap<TblUser,TblUserListDto>().ReverseMap();
            CreateMap<TblUser,TblUserUpdateDto>().ReverseMap();
        }
    }
}
