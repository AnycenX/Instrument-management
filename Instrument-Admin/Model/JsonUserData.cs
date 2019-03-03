using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InM_Admin.Model
{
    class JsonUserData
    {
        public class Data
        {
            /// <summary>
            /// Id
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// anycen
            /// </summary>
            public string username { get; set; }
            /// <summary>
            /// 21232f297a57a5a743894a0e4a801fc3
            /// </summary>
            public string password { get; set; }
            /// <summary>
            /// 6ed6hf
            /// </summary>
            public string passsalt { get; set; }
            /// <summary>
            /// Rank
            /// </summary>
            public int rank { get; set; }
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
            public object data { get; set; }
        }

    }
}
