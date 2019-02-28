using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InM
{
    public class InfoWithVer<T>
    {
        public int version;
        public DateTime updateTime;
        public T[] info;
    }
}
