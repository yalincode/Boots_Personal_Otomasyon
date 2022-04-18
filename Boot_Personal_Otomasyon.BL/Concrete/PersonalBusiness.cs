using Boots_Personal_Otomasyon.BL.Abstract;
using Boots_Personal_Otomasyon.DAL.Concrete;
using Boots_Personal_Otomasyon.DAL.Migrations;
using Boots_Personal_Otomasyon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.BL.Concrete
{
    public class PersonalBusiness : IPersonalBusiness
    {
        private IPersonalRepository _personalRepo;
        public PersonalBusiness(IPersonalRepository personalRepo)
        {
            _personalRepo = personalRepo;
        }
        public async Task Add(Personal entity)
        {
            await _personalRepo.Add(entity);    
        }

        public async Task DeleteById(int id)
        {
            await _personalRepo.DeleteById(id);
        }

        public IQueryable<Personal> GetAll(Func<Personal, bool> predicate=null)
        {
            return _personalRepo.GetAll(predicate);
        }

        public async Task<Personal> GetById(int id)
        {
            return await _personalRepo.GetById(id);
        }

        public async Task Update(Personal entity)
        {
            await _personalRepo.Update(entity);
        }
    }
}
