using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingsApp
{
    internal class TimeGreetings
    {
        string _morning = "Good morning";
        string _day = "Good day";
        string _evening = "Good evening";
        string _night = "Good night";

        public string GetMessage()
        {
            var hourNow = DateTime.Now.Hour;

            string message = hourNow switch
            {
                >= 5 and < 10 => _morning,
                >= 10 and < 18 => _day,
                >= 18 and < 23 => _evening,
                >= 23 or < 5 => _night,
            };

            return message;
        }
    }
}
