using AutoMapper;
using ProfileApp.Dto.TblUserAccountDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Mappings.AutoMapper
{
    public class TblUserAccountProfile : Profile
    {
        public TblUserAccountProfile()
        {
            CreateMap<TblUserAccounts,TblUserAccountCreateDto>().ReverseMap();
            CreateMap<TblUserAccounts,TblUserAccountListDto>().ReverseMap();
            CreateMap<TblUserAccounts,TblUserAccountUpdateDto>().ReverseMap();
        }
    }
}
