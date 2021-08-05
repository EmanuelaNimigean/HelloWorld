using HelloWorldWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        int AddTeamMember(string name);

        TeamInfo GetTeamInfo();

        void DeleteTeamMember(int index);

        TeamMember GetTeamMemberById(int id);

    }
}