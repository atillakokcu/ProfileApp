using ProfileApp.Dto.TblActivationDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Interfaces
{
    public interface IActivaitonService : IService<TblActivationCreateDto, TblActivationUpdateDto, TblActivationListDto, TblActivation>
    {
        Task<bool> ActivaitonCheck(TblActivationListDto dto);
        Task<bool> ActivatonStattusReserve(int AktivationId);
    }
}
