using ProfileApp.Dto.Interfaces;
using ProfileApp.Dto.TblAppRoleDtos;
using ProfileApp.Dto.TblUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Dto.TblUserRoleDtos
{
    public class TblUserRoleListDto : IDto
    {
        public int UserId { get; set; }
        public TblUserListDto TblUser { get; set; }

        public int RoleId { get; set; }
        public TblAppRoleListDto TblAppRole { get; set; }
    }
}
