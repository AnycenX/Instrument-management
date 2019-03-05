using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InM
{
    public class StorageModel
    {
        public InfoWithVer<UserInfo> userInfo;
        public InfoWithVer<ProcessInfo> processInfo;
        public InfoWithVer<UpdateInfo> updateInfo;
    }
}
