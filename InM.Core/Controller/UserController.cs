using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InM
{
    public class UserChangedArgs
    {
        public UserChangedArgs(string Username, bool isAdmin = false)
        {
            LoggedinUser = Username;
            this.isAdmin = isAdmin;
        }
        public bool isLoggedin { get => !string.IsNullOrEmpty(LoggedinUser); }
        public string LoggedinUser { get; }
        public bool isAdmin { get; }
    }
    public class UserController
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public bool isLoggedin { get => !string.IsNullOrEmpty(LoggedinUser); }
        public string LoggedinUser { get; protected set; }
        public bool isAdmin { get; protected set; }

        public delegate void UserChangedHandler(object sender, UserChangedArgs e);
        public event UserChangedHandler UserChanged;
        public void Login(string name, string password)
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
            LoggedinUser = user.username;
            isAdmin = user.rank == 1;
            logger.Info($"账号登录：{LoggedinUser},管理员：{isAdmin}");
            UserChanged?.Invoke(this, new UserChangedArgs(LoggedinUser, isAdmin));
        }

        public void Logout()
        {
            logger.Info($"账号退出：{LoggedinUser}");
            UserChanged?.Invoke(this, new UserChangedArgs(null));
        }
    }
}
