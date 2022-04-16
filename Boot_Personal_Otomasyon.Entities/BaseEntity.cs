using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? RecourDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }//Bu kaydı kim güncellemiş
        public int? RecordededUserId { get; set; }//Bu kaydı kim eklemiş
    }
}
