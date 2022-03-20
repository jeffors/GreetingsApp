using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingsApp
{
    internal class LangsReader
    {
        public Dictionary<string, TimesOfDay>? LangMessages { get; set; }
    }

    internal class TimesOfDay
    {
        public string? Morning { get; set; }
        public string? Day { get; set; }
        public string? Evening { get; set; }
        public string? Night { get; set; }
    }


}
