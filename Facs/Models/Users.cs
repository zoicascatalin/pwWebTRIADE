using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facs.Models
{
    public class Users
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool CheckedOut { get; set; }
        public int Role { get; set; }
        public int NR_Camera { get; set; }
    }
}
