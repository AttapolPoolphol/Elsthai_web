using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elsthai_web.Models
{
    public class Staff
    {
        public string staff_id { get; set; }
        public string password_staff { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string isdelete { get; set; }
    }
}
