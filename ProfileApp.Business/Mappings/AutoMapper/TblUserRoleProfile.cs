using AutoMapper;
using ProfileApp.Dto.TblUserDtos;
using ProfileApp.Dto.TblUserRoleDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Mappings.AutoMapper
{
    public class TblUserRoleProfile : Profile
    {
        public TblUserRoleProfile()
        {
            CreateMap<TblUserRole,TblUserRoleListDto>().ReverseMap();
            CreateMap<TblUserRole,UserListWithRole>().ReverseMap();
        }
    }
}
