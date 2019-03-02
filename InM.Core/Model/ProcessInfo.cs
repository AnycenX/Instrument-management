using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InM
{
    public class ProcessInfo
    {
        public string name;
        public string process;
        public string type;
    }

    public class ProcessUplogModel
    {
        public string username;
        public string name;
        public string process;
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime start;
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime stop;
    }
}
