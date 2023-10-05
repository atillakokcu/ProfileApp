using ProfileApp.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Dto.TblStatusDtos
{
    public class TblStatusCreateDto : IDto
    {
        public string StatusName { get; set; }
    }
}
