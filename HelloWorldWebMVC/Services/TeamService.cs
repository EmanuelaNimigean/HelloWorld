using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWebMVC.Models;
using HelloWorldWebMVC.Services;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;
        private ITimeService timeService;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "~Team 1~",
                TeamMembers = new List<TeamMember>(),
            };
            this.AddTeamMember("Sorina", (TimeService)this.timeService);
            this.AddTeamMember("Ema", (TimeService)this.timeService);
            this.AddTeamMember("Patrick", (TimeService)this.timeService);
            this.AddTeamMember("Tudor", (TimeService)this.timeService);
            this.AddTeamMember("Radu", (TimeService)this.timeService);
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            // foreach (TeamMember member in this.teamInfo.TeamMembers)
            // {
            //    if (member.Id == id)
            //    {
            //        return member;
            //    }

            // }

            // return null;
            Console.WriteLine(id);
            return this.teamInfo.TeamMembers.Find(x => x.Id == id);
        }

        public int AddTeamMember(string name, ITimeService timeService)
        {
            TeamMember member = new TeamMember(name, timeService);
            this.teamInfo.TeamMembers.Add(member);
            return member.Id;
        }

        public void DeleteTeamMember(int id)
        {
            this.teamInfo.TeamMembers.Remove(this.GetTeamMemberById(id));
        }

        public void EditTeamMember(int id, string name)
        {
            this.GetTeamMemberById(id).Name = name;
        }
    }
}