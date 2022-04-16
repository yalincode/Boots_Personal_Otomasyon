using System;

namespace Boots_Personal_Otomasyon.WEBUI.Models
{
    public class PersonalVM
    {
        public int Id { get; set; }
        public string NameAndSurname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdentifierNumber { get; set; }
        public string Address { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Linkedln { get; set; }

        public int? DepartmantId { get; set; }
        
    }
}
