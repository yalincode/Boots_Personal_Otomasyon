using Boots_Personal_Otomasyon.DAL.Migrations;
using Boots_Personal_Otomasyon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.BL.Abstract
{
    public interface IPersonalBusiness
    {
        IQueryable<Personal> GetAll(Func<Personal, bool> predicate=null);

        //GERİ DÖNÜŞ TİPİ T OLMUŞ OLUR
        Task<Personal> GetById(int id);
        Task Add(Personal entity);
        Task Update(Personal entity);
        Task DeleteById(int id);
    }
}
