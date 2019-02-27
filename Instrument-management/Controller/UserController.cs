using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument_management
{
    public class UserController
    {
        public static void Login(string name, string password)
        {
            var users = from x in SharedData.userInfo where x.username == name select x;
            if (users.Count() == 0)
            {
                throw new Exception("用户名错误");
            }
            var user = users.ElementAt(0);
            if (Encryption.MD5HashWithSalt(password, user.passsalt) != user.password)
            {
                throw new Exception("密码错误");
            }
            SharedData.LoggedinUser = user.username;
            SharedData.isAdmin = user.rank == 1;
        }
    }
}
