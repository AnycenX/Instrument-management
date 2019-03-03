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
        public int id { get; set; }
        public string name { get; set; }
        public string process { get; set; }
        public string type { get; set; }
    }

    public class ProcessUplogModel
    {
        public string username { get; set; }
        public string name { get; set; }
        public string process { get; set; }
        [JsonConverter(typeof(UnixDateTimeTimezoneConverter))]
        public DateTime timestart { get; set; }
        [JsonConverter(typeof(UnixDateTimeTimezoneConverter))]
        public DateTime timestop { get; set; }
    }

    public class UnixDateTimeTimezoneConverter : UnixDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) 
            => TimeZone.CurrentTimeZone.ToLocalTime((DateTime)base.ReadJson(reader, objectType, existingValue, serializer));
    }
}
