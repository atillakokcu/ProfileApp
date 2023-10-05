using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Entity
{
    public class TblUserAccounts : BaseEntity
    {
        public string AccountName { get; set; }
        public string AccountUrl { get; set; }

        public int UserId { get; set; }
        public TblUser TblUser { get; set; }
    }
}
