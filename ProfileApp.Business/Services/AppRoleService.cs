using AutoMapper;
using FluentValidation;
using ProfileApp.Business.Interfaces;
using ProfileApp.DataAccess.UnitOfWork;
using ProfileApp.Dto.TblAppRoleDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Services
{
    public class AppRoleService : Service<TblAppRoleCreateDto, TblAppRoleUpdateDto, TblAppRoleListDto, TblAppRole>, IAppRoleService
    {
        private readonly IUow _uow;
        public AppRoleService(IMapper mapper, IValidator<TblAppRoleCreateDto> createDtoValidator, IValidator<TblAppRoleUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
        }

        public async Task<TblUserRole> FindUserId(int Id)
        {
           return await _uow.GetRepository<TblUserRole>().GetByFilterAsync(x => x.UserId == Id);
        }


    }
}
