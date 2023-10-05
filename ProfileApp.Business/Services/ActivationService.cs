using AutoMapper;
using FluentValidation;
using ProfileApp.Business.Interfaces;
using ProfileApp.DataAccess.UnitOfWork;
using ProfileApp.Dto.TblActivationDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Services
{
    public class ActivationService : Service<TblActivationCreateDto, TblActivationUpdateDto, TblActivationListDto, TblActivation>, IActivaitonService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public ActivationService(IMapper mapper, IValidator<TblActivationCreateDto> createDtoValidator, IValidator<TblActivationUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {


            _mapper = mapper;
            _uow = uow;

        }


        public async Task<bool> ActivaitonCheck(TblActivationListDto dto)
        {
           

            var code = (await _uow.GetRepository<TblActivation>().GetAllAsync(x=>x.ActivationCode == dto.ActivationCode)).FirstOrDefault();

            var ChangeData = new TblActivation();
            ChangeData.ActivationCode = dto.ActivationCode;
            ChangeData.StatusId = 2;
            ChangeData.Id = code.Id;

            if (code != null && code.StatusId==1 || code.StatusId==3) 
            {
                var data = await _uow.GetRepository<TblActivation>().FindAsync(code.Id);
                _uow.GetRepository<TblActivation>().Update(ChangeData, data);
               await _uow.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> ActivatonStattusReserve(int AktivationId)
        {
            var data = await _uow.GetRepository<TblActivation>().GetByFilterAsync(x=>x.Id == AktivationId);
            var changeData = new TblActivation();
           
            changeData.StatusId = 3;
            changeData.Id = data.Id;
            changeData.Status = data.Status;
            changeData.ActivationCode= data.ActivationCode;
            if (data!=null)
            {
                var Data = await _uow.GetRepository<TblActivation>().FindAsync(data.Id);
                _uow.GetRepository<TblActivation>().Update(changeData, Data);
                await _uow.SaveChangesAsync();
                return true;
            }
            return false;
            
            
           
            
        }



    }
}
