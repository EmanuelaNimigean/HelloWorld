using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebMVC.Services
{
    public class TimeService : ITimeService
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}