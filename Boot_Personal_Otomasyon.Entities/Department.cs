using System.Collections.Generic;

namespace Boots_Personal_Otomasyon.Entities
{
    public class Department:BaseEntity
    {
        public Department()
        {
            this.Personals = new List<Personal>();
        }
        
        public string DepartmentName { get; set; }

        public ICollection<Personal> Personals { get; set; }
    }
}