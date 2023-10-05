using ProfileApp.Dto.TblUserAccountDtos;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Business.Interfaces
{
    public interface IUserAccountService : IService<TblUserAccountCreateDto,TblUserAccountUpdateDto,TblUserAccountListDto,TblUserAccounts>
    {
    }
}
