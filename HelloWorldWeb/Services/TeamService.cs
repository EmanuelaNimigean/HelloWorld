// <copyright file="TeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using HelloWorldWeb.Models;
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
            this.teamInfo = new TeamInfo
            {
                Name = "~Team 1~",
                TeamMembers = new List<TeamMember>(),
            };

            this.broadcastService = broadcastService;

            this.AddTeamMember("Sorina");
            this.AddTeamMember("Tudor");
            this.AddTeamMember("Ema");
            this.AddTeamMember("Patrick");
            this.AddTeamMember("Radu");
            this.AddTeamMember("Fineas");
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            Console.WriteLine(id);
            return this.teamInfo.TeamMembers.Find(x => x.Id == id);
        }

        public int AddTeamMember(string name)
        {
            TeamMember teamMember = new (name, this.timeService);
            this.teamInfo.TeamMembers.Add(teamMember);
            this.broadcastService.TeamMemberAdded(teamMember.Name, teamMember.Id);
            return teamMember.Id;
        }

        public void DeleteTeamMember(int id)
        {
            this.teamInfo.TeamMembers.Remove(this.GetTeamMemberById(id));
            this.broadcastService.TeamMemberDeleted(id);
        }

        public void EditTeamMemberName(string name, int id)
        {
            this.GetTeamMemberById(id).Name = name;
            this.broadcastService.TeamMemberEdit(name, id);
        }
    }
}
