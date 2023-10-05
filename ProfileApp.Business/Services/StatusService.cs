using AutoMapper;
using FluentValidation;
using ProfileApp.Business.Interfaces;
using ProfileApp.DataAccess.UnitOfWork;
using ProfileApp.Dto.TblStatusDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Services
{
    public class StatusService : Service<TblStatusCreateDto, TblStatusUpdateDto, TblStatusListDto, TblStatus>, IStatusService
    {
        private readonly IUow _uow;
        public StatusService(IMapper mapper, IValidator<TblStatusCreateDto> createDtoValidator, IValidator<TblStatusUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
        }
        
    }
}
