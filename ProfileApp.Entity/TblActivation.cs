using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Entity
{
    public class TblActivation : BaseEntity
    {
        public string ActivationCode { get; set; }

        public int StatusId { get; set; }
        public TblStatus Status { get; set; }
    }
}
