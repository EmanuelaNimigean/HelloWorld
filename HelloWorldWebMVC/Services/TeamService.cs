using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWebMVC;
using HelloWorldWebMVC.Models;
using HelloWorldWebMVC.Services;
using Microsoft.AspNetCore.SignalR;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;
        private readonly ITimeService timeService;
        private readonly IBroadcastService broadcastService;

        public TeamService(IBroadcastService broadcastService)
        {
            // this.messageHub = messageHubContext;
            this.broadcastService = broadcastService;
            this.teamInfo = new TeamInfo
            {
                Name = "~Team 1~",
                TeamMembers = new List<TeamMember>(),
            };
            this.AddTeamMember("Sorina");
            this.AddTeamMember("Ema");
            this.AddTeamMember("Patrick");
            this.AddTeamMember("Tudor");
            this.AddTeamMember("Radu");
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        // public int AddTeamMember(string name)
        // {
        //    int newId = this.teamInfo.TeamMembers.Count + 1;
        //    this.teamInfo.TeamMembers.Add(new TeamMember(name));
        //    this.messageHub.Clients.All.SendAsync("NewTeamMemberAdded", name, newId);
        //    return newId;
        // }
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

        public int AddTeamMember(string name)
        {
            TeamMember member = new TeamMember(name, this.timeService);
            this.teamInfo.TeamMembers.Add(member);
            this.broadcastService.NewTeamMemberAdded(name, member.Id);
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