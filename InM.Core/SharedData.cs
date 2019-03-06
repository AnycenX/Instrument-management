using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InM
{
    public static class SharedData
    {
        public static UserController User = new UserController();

        public static InfoWithVer<UserInfo> userInfoVer;
        public static UserInfo[] userInfo { get => userInfoVer?.info ?? new UserInfo[0]; }
        public static InfoWithVer<ProcessInfo> processInfoVer;
        public static ProcessInfo[] processInfo { get => processInfoVer?.info ?? new ProcessInfo[0]; }
        public static InfoWithVer<UpdateInfo> updateInfoVer;
        public static StartInfo startInfo
        {
            get => new StartInfo()
            {
                update = updateInfoVer.version,
                userinfo = userInfoVer.version,
                processinfo = processInfoVer.version
            };
        }

        public static IEnumerable<string> processList { get => from x in processInfo select x.process; }

        public static string LoggedinUser { get => User.LoggedinUser; }
        public static bool isLoggedin { get => User.isLoggedin; }
        public static bool isAdmin { get => User.isAdmin; }

        public static string currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public static string dataPath = Path.Combine(currentPath, "data.bin");
    }
}
