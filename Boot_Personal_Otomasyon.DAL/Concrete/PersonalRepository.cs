using Boots_Personal_Otomasyon.DAL.Context.EF;
using Boots_Personal_Otomasyon.DAL.Migrations;
using Boots_Personal_Otomasyon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Concrete
{
    public class PersonalRepository:GenericRepository<Personal>, IPersonalRepository
    {
        public PersonalRepository(PersonalContext Db):base(Db)
        {

        }
    }
}
