using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.BL.Abstract
{
    using DTO;
    public interface IUserBusiness
    {
        UserDTO GetUser(string username,string password);
    }
}
