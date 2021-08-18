using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWebMVC.Models;
using HelloWorldWebMVC.Services;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        int AddTeamMember(string name);

        int AddTeamMember(string name, ITimeService timeService);

        TeamInfo GetTeamInfo();

        void DeleteTeamMember(int id);

        void EditTeamMember(int id, string name);

        TeamMember GetTeamMemberById(int id);
    }
}