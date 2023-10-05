using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Entity
{
    public class TblUserRole : BaseEntity
    {
        public int UserId { get; set; }
        public TblUser TblUser { get; set; }

        public int RoleId { get; set; }
        public TblAppRole TblAppRole { get; set; }
    }
}
