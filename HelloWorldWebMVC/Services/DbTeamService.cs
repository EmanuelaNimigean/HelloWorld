using HelloWorldWeb.Services;
using HelloWorldWebMVC.Data;
using HelloWorldWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebMVC.Services
{
    public class DbTeamService:ITeamService
    {
        private readonly ApplicationDbContext _context;

        public DbTeamService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public int AddTeamMember(string name)
        {
            TeamMember teamMember = new TeamMember(name);
            this._context.Add(teamMember);
            this._context.SaveChanges();
            return teamMember.Id;
        }

        public TeamInfo GetTeamInfo()
        {
            var teamMembersList = this._context.TeamMembers.ToList();
            TeamInfo teamInfo = new TeamInfo();
            teamInfo.Name = "Ema";
            teamInfo.TeamMembers = teamMembersList;
            return teamInfo;
        }

        public TeamMember GetTeamMemberById()
        {
            throw new NotImplementedException();
        }

        public void DeleteTeamMember(int id)
        {
            throw new NotImplementedException();
        }

        public void EditTeamMember(int id, string name)
        {
            throw new NotImplementedException();
        }

        public TeamMember GetTeamMemberById(int id)
        {
            throw new NotImplementedException();
        }

        public int AddTeamMember(string name, ITimeService timeService)
        {
            throw new NotImplementedException();
        }
    }
}
