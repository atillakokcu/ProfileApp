using AutoMapper;
using FluentValidation;
using ProfileApp.Business.Interfaces;
using ProfileApp.DataAccess.UnitOfWork;
using ProfileApp.Dto.TblStatusDtos;
using ProfileApp.Dto.TblUserAccountDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Services
{
    public class UserAccountService : Service<TblUserAccountCreateDto, TblUserAccountUpdateDto, TblUserAccountListDto, TblUserAccounts>, IUserAccountService
    {
        public UserAccountService(IMapper mapper, IValidator<TblUserAccountCreateDto> createDtoValidator, IValidator<TblUserAccountUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
