using ProfileApp.Common;
using ProfileApp.Dto.TblAppRoleDtos;
using ProfileApp.Dto.TblUserAccountDtos;
using ProfileApp.Dto.TblUserDtos;
using ProfileApp.Dto.TblUserRoleDtos;
using ProfileApp.Entity;

namespace ProfileApp.Business.Interfaces
{
    public interface IUserService:IService<TblUserCreateDto,TblUserUpdateDto,TblUserListDto,TblUser>
    {
        Task<IResponse<TblUserListDto>> CheckUserAsync(UserLoginDto dto);
        Task<IResponse<List<TblAppRoleListDto>>> GetRolesByUserIdAsync(int userId);
        Task<IResponse<TblUserCreateDto>> CreateWithRoleAsync(TblUserCreateDto dto, int roleId);
        Task<List<TblUserAccountListDto>> UserAccountList(int UserId);
		Task<IResponse<TblUser>> UserInformationGuid(Guid GuidId);
        Task<List<TblUserRoleListDto>> UserListWithRoleStatus();
        Task<bool> UserControl(string Username);
        Task<bool> AdminCheckControl(string Username);

    }
    
}
