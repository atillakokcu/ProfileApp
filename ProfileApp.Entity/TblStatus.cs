using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Entity
{
    public class TblStatus : BaseEntity
    {
        public string StatusName { get; set; }

        public List<TblActivation> TblActivation { get; set; }
        public List<TblUser> TblUser { get; set; }
    }
}
