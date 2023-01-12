using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elsthai_web.Models
{
    public class User
    {
        public string user_id { get; set; }
        public string password_user { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string isdelete { get; set; }
    }
}
