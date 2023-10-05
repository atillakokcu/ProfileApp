using ProfileApp.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Dto.TblUserAccountDtos
{
    public class TblUserAccountListDto : IDto
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountUrl { get; set; }

        public int UserId { get; set; }
    }
}
