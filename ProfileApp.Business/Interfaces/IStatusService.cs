using ProfileApp.Business.Services;
using ProfileApp.Dto.TblStatusDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Interfaces
{
    public interface IStatusService : IService<TblStatusCreateDto,TblStatusUpdateDto,TblStatusListDto,TblStatus>
    {
       
    }
}
