// <copyright file="ITeamService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
            int AddTeamMember(string name);

            void DeleteTeamMember(int id);

            TeamMember GetTeamMemberById(int id);

            void EditTeamMemberName(string name, int id);

            TeamInfo GetTeamInfo();
    }
}