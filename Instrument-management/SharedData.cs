using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InM
{
    public static class SharedData
    {
        public static InfoWithVer<UserInfo> userInfoVer;
        public static UserInfo[] userInfo { get => userInfoVer.info; }
        public static InfoWithVer<ProcessInfo> processInfoVer;
        public static ProcessInfo[] processInfo { get => processInfoVer.info; }
        public static IEnumerable<string> processList { get => from x in processInfo select x.process; }
        public static string LoggedinUser;
        public static bool isLoggedin { get => !string.IsNullOrEmpty(LoggedinUser); }
        public static bool isAdmin;
    }
}
