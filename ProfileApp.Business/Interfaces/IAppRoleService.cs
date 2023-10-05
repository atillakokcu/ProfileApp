using ProfileApp.Business.Services;
using ProfileApp.Dto.TblAppRoleDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Interfaces
{
    public interface IAppRoleService : IService<TblAppRoleCreateDto,TblAppRoleUpdateDto,TblAppRoleListDto,TblAppRole>
    {
        Task<TblUserRole> FindUserId(int Id);
    }
}
