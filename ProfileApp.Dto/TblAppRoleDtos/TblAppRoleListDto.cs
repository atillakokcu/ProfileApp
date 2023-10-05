using ProfileApp.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Dto.TblAppRoleDtos
{
    public class TblAppRoleListDto : IDto
    {
        public int Id { get; set; }
        public string Defination { get; set; }

        
    }
}
