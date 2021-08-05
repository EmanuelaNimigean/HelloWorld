﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWebMVC.Models;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "~Team 1~",
                TeamMembers = new List<TeamMember>(),
            };
            this.teamInfo.TeamMembers.Add(new TeamMember("Sorina"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Ema"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Patrick"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Tudor"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Radu"));
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            //foreach (TeamMember member in this.teamInfo.TeamMembers)
            //{
            //    if (member.Id == id)
            //    {
            //        return member;
            //    }

            //}
            //return null;
            Console.WriteLine(id);
            return this.teamInfo.TeamMembers.Find(x => x.Id == id);
        }

        public int AddTeamMember(string name)
        {
            TeamMember member = new TeamMember(name);
            this.teamInfo.TeamMembers.Add(member);
            return member.Id;
        }

        public void DeleteTeamMember(int index)
        {
           
            this.teamInfo.TeamMembers.Remove(this.GetTeamMemberById(index));
        }

    }
}