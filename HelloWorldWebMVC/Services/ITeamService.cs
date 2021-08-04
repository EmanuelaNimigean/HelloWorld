using HelloWorldWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        void AddTeamMember(string name);

        TeamInfo GetTeamInfo();
    }
}