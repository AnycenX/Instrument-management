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
        public string name;
        public string friendlyName;
        public DateTime start;
        public DateTime stop;
    }
}
