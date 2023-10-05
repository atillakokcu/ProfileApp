using ProfileApp.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Dto.TblActivationDtos
{
    public class TblActivationListDto : IDto
    {
        public int Id { get; set; }
        public string ActivationCode { get; set; }

        public int StatusId { get; set; }
    }
}
