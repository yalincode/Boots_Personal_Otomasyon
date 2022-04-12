using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Abstract
{
    using DTO;
    public interface IUserRepository
    {
        UserDTO GetUser(string username,string password);
    }
}
