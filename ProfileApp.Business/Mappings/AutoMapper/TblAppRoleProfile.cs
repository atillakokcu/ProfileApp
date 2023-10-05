using AutoMapper;
using ProfileApp.Dto.TblAppRoleDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Mappings.AutoMapper
{
    public class TblAppRoleProfile : Profile
    {
        public TblAppRoleProfile()
        {
            CreateMap<TblAppRole,TblAppRoleCreateDto>().ReverseMap();
            CreateMap<TblAppRole,TblAppRoleListDto>().ReverseMap();
            CreateMap<TblAppRole,TblAppRoleUpdateDto>().ReverseMap();
        }
    }
}
