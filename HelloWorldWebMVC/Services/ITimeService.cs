using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebMVC.Services
{
    public interface ITimeService
    {
        public DateTime GetNow();
    }
}
