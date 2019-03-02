using InM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InM_Admin
{
    public class ProcessUplogModelEx : ProcessUplogModel
    {
        public TimeSpan timeSpan { get => timestop - timestart; }
    }
}
