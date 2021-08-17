using HelloWorldWeb.Services;
using HelloWorldWebMVC.Data;
using HelloWorldWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebMVC.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext context;

        public DbTeamService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int AddTeamMember(string name)
        {
            TeamMember teamMember = new TeamMember(name);
            teamMember.Birthdate = new DateTime(2000, 12, 12);
            this.context.Add(teamMember);
            this.context.SaveChanges();
            return teamMember.Id;
        }

        public void EditTeamMember(int id, string name)
        {
            var teamMember = this.context.TeamMembers.Find(id);
            teamMember.Name = name;
            this.context.Update(teamMember);
            this.context.SaveChanges();
        }

        public void DeleteTeamMember(int id)
        {
            var teamMember = this.context.TeamMembers.Find(id);
            this.context.TeamMembers.Remove(teamMember);
            this.context.SaveChanges();
        }

        public TeamInfo GetTeamInfo()
        {
            var teamMembersList = this.context.TeamMembers.ToList();
            TeamInfo teamInfo = new TeamInfo();
            teamInfo.Name = "Team example";
            teamInfo.TeamMembers = teamMembersList;
            return teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
