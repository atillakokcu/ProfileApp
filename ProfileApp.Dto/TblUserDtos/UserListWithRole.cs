using ProfileApp.Dto.Interfaces;
using ProfileApp.Dto.TblAppRoleDtos;
using ProfileApp.Dto.TblStatusDtos;
using ProfileApp.Dto.TblUserDtos;

namespace ProfileApp.Dto.TblUserDtos
{
    public class UserListWithRole : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public TblUserListDto User { get; set; }

        public int RoleId { get; set; } 
        public TblAppRoleListDto Role { get; set; }

        public int StatusId { get; set; }
        public TblStatusListDto Status { get; set; }
    }
}
