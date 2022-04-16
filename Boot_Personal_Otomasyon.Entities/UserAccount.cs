using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.Entities
{
    public class UserAccount:BaseEntity
    {
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
