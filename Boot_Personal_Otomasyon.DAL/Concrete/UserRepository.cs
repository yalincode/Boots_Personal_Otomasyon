using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Concrete
{
    using Abstract;
    using Boots_Personal_Otomasyon.DAL.Context.EF;
    using Boots_Personal_Otomasyon.DTO;

    public class UserRepository : IUserRepository
    {
        private PersonalContext _context;
        public UserRepository(PersonalContext context)
        {
            _context= context;
        }
        public UserDTO GetUser(string username, string password)
        {
            return _context.UserAccount.Where(t=>t.UserName == username && t.Password == password)
                .Select(t1=>new UserDTO{ FullName=t1.FullName,UserAccountId=t1.UserAccountId,UserName=t1.UserName})
                .FirstOrDefault();

            //return (from t in _context.UserAccount
            //        where t.UserName == username && t.Password == password
            //        select new UserDTO
            //        {
            //            FullName=t.FullName,
            //            UserAccountId=t.UserAccountId,
            //            UserName=t.UserName,
            //        }).FirstOrDefault();
        }
    }
}
