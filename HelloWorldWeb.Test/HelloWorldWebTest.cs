using HelloWorldWeb.Services;
using System;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();
            //Act
            teamService.AddTeamMember("George");
            //Assert
            Assert.Equal(4, teamService.GetTeamInfo().TeamMembers.Count);
           
        }
    }
}
