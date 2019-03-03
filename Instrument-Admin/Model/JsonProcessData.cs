using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InM_Admin.Model
{
    class JsonProcessData
    {
        public class Data
        {
            /// <summary>
            /// Id
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 软件名称1
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// tasges
            /// </summary>
            public string process { get; set; }
            /// <summary>
            /// exe
            /// </summary>
            public string type { get; set; }
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
            public List<Data> data { get; set; }
        }

    }
}
