using ProfileApp.Dto.TblUserAccountDtos;

namespace ProfileApp.UI.Models
{
	public class UserProfileModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string ImageUrl { get; set; }
		public Guid UserNamGuidId { get; set; }
		public List<TblUserAccountListDto> UserAccounts { get; set; }
	}
}
