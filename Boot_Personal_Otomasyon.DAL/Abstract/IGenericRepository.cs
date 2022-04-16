using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Abstract
{
    public interface IGenericRepository<T>
    {
        //Function=metot
        //bool predicate(T param)
        //{
        //    return false;
        //} ====================================> Bu Func<T,bool> predicate => Aynı şeydir
        IQueryable<T> GetAll(Func<T,bool> predicate);

        //GERİ DÖNÜŞ TİPİ T OLMUŞ OLUR
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task DeleteById(int id);

        
    }
}
