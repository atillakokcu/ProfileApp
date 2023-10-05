namespace ProfileApp.UI.Areas.Admin.Models
{
    public class UpdateUserDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public Guid UserNamGuidId { get; set; }
        public string MailAdress { get; set; }

        public int StatusId { get; set; }
        public int RoleId { get; set; }
    }
}

