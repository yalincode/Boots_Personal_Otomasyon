using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.Entities
{
    public class Personal:BaseEntity
    {
        
        public string NameAndSurname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdentifierNumber { get; set; }
        public string Address { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Linkedln { get; set; }

        public int? DepartmantId{ get; set; }
        public Department Department{ get; set; }
    }
}
