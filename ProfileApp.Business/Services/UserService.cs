using AdvertisementApp.Business.Extensions;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProfileApp.Business.Interfaces;
using ProfileApp.Common;
using ProfileApp.DataAccess.UnitOfWork;
using ProfileApp.Dto.TblAppRoleDtos;
using ProfileApp.Dto.TblUserAccountDtos;
using ProfileApp.Dto.TblUserDtos;
using ProfileApp.Dto.TblUserRoleDtos;
using ProfileApp.Entity;

namespace ProfileApp.Business.Services
{
    public class UserService : Service<TblUserCreateDto, TblUserUpdateDto, TblUserListDto, TblUser>, IUserService
	{
		private readonly IAppRoleService _roleService;
		private readonly IMapper _mapper;
		private readonly IUow _uow;
		private readonly IValidator<TblUserCreateDto> _userCreateValidator;
		private readonly IValidator<UserLoginDto> _UserLoginValidator;
        public UserService(IMapper mapper, IValidator<TblUserCreateDto> createDtoValidator, IValidator<TblUserUpdateDto> updateDtoValidator, IUow uow, IValidator<TblUserCreateDto> userCreateValidator, IValidator<UserLoginDto> userLoginValidator
, IAppRoleService roleService) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {

            _mapper = mapper;
            _uow = uow;
            _userCreateValidator = userCreateValidator;
            _UserLoginValidator = userLoginValidator;
            _roleService = roleService;
        }



        public async Task<IResponse<TblUserListDto>> CheckUserAsync(UserLoginDto dto)
		{
			var validationresult = _UserLoginValidator.Validate(dto);
			if (validationresult.IsValid)
			{
				var user = await _uow.GetRepository<TblUser>().GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);
				if (user != null)
				{
					var appuserDto = _mapper.Map<TblUserListDto>(user);
					return new Response<TblUserListDto>(ResponseType.Success, appuserDto);
				}

				return new Response<TblUserListDto>(ResponseType.NotFount, "Username or password incorrect");
			}
			return new Response<TblUserListDto>(ResponseType.ValidationError, "Username or password cannot be empty");
		}

		public async Task<IResponse<TblUserCreateDto>> CreateWithRoleAsync(TblUserCreateDto dto, int roleId)
		{
			var validationResult = _userCreateValidator.Validate(dto);
			if (validationResult.IsValid)
			{
				var user = _mapper.Map<TblUser>(dto);
				await _uow.GetRepository<TblUser>().CreateAsync(user);
				await _uow.GetRepository<TblUserRole>().CreateAsync(new TblUserRole
				{
					RoleId = roleId,
					TblUser = user
				});
				await _uow.SaveChangesAsync();
				return new Response<TblUserCreateDto>(ResponseType.Success, dto);
			}
			return new Response<TblUserCreateDto>(dto, validationResult.ConvertToCustomValidationError());
		}

		public async Task<IResponse<List<TblAppRoleListDto>>> GetRolesByUserIdAsync(int userId)
		{
			var roles = await _uow.GetRepository<TblAppRole>().GetAllAsync(x => x.UserRoles.Any(x => x.UserId == userId));

			if (roles == null)
			{
				return new Response<List<TblAppRoleListDto>>(ResponseType.NotFount, "İlgili rol bulunamadı");
			}
			var dto = _mapper.Map<List<TblAppRoleListDto>>(roles);
			return new Response<List<TblAppRoleListDto>>(ResponseType.Success, dto);


		}

		public async Task<List<TblUserAccountListDto>> UserAccountList(int UserId)
		{

			var UserAccountProfile = await _uow.GetRepository<TblUserAccounts>().GetAllAsync(x => x.UserId == UserId);

			var changeUserAccountProfile = _mapper.Map<List<TblUserAccountListDto>>(UserAccountProfile);

			return new List<TblUserAccountListDto>(changeUserAccountProfile);

		}

		public async Task<IResponse<TblUser>> UserInformationGuid(Guid GuidId)
		{
			var UserProfile = await _uow.GetRepository<TblUser>().GetAllAsync(x => x.UserNamGuidId == GuidId);

			//var Userprofilem=  _mapper.Map<TblUserListDto>(UserProfile);
			if (UserProfile != null)
			{
				return new Response<TblUser>(ResponseType.Success, UserProfile.SingleOrDefault());
			}

			return new Response<TblUser>(ResponseType.ValidationError, "User profiles empty");

		}


		public async Task<List<TblUserRoleListDto>> UserListWithRoleStatus()
		{
			var query = _uow.GetRepository<TblUserRole>().GetQuery();
            var UserRole = await _roleService.GetAllAsync();
			var list = await query.Include(x => x.TblAppRole).Include(x => x.TblUser).ToListAsync();
            return _mapper.Map<List<TblUserRoleListDto>>(list);
				

		}

		public async Task< bool> UserControl(string Username)
		{
			var user = await _uow.GetRepository<TblUser>().GetByFilterAsync(x => x.Username == Username);
			if (user==null)
			{
				return true;
			}

			return false;
        }



        public async Task<bool> AdminCheckControl(string Username)
        {
            var query = _uow.GetRepository<TblUserRole>().GetQuery();
            var list = await query.Include(x => x.TblAppRole).Include(x => x.TblUser).ToListAsync();
			foreach (var item in list)
			{
				if (item.TblUser.Username == Username && item.RoleId==1)
				{
					return true;
				}
				
			}
			return false;


        }

    }
}
