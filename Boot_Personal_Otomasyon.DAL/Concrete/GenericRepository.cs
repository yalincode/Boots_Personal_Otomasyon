using Boots_Personal_Otomasyon.DAL.Abstract;
using Boots_Personal_Otomasyon.DAL.Context.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Concrete
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private PersonalContext _Db;
        public GenericRepository(PersonalContext Db)
        {
            _Db= Db;
        }
        public virtual async Task Add(T entity)
        {
            await _Db.Set<T>().AddAsync(entity);
            await _Db.SaveChangesAsync();

        }

        public virtual async Task DeleteById(int id)
        {
            var entity=await GetById(id);
            _Db.Set<T>().Remove(entity);
            await _Db.SaveChangesAsync();
        }

        public virtual IQueryable<T> GetAll(Func<T, bool> predicate)
        {
            return _Db.Set<T>().Where(predicate).AsQueryable();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _Db.Set<T>().FindAsync(id);

        }

        public virtual async Task Update(T entity)
        {
            _Db.Set<T>().Update(entity);
            await _Db.SaveChangesAsync();
        }
    }
}
