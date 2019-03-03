using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InM_Admin.Model
{
    class JsonStartData
    {
        public class Data
        {
            /// <summary>
            /// Update
            /// </summary>
            public int update { get; set; }
            /// <summary>
            /// Userinfo
            /// </summary>
            public int userinfo { get; set; }
            /// <summary>
            /// Processinfo
            /// </summary>
            public int processinfo { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// Code
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// Data
            /// </summary>
            public Data data { get; set; }
        }
    }
}
