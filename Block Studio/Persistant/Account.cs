using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockStudio.Persistant
{
    public class Account
    {
        public string AccountId { get; set; }
        public string Password { get; set; }

        public bool Locked{ get; set; }
    }
}
