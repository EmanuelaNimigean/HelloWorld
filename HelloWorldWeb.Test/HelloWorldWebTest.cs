using HelloWorldWeb.Services;
using HelloWorldWebMVC.Services;
using Moq;
using System;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamServiceTest
    {
        private IBroadcastService broadcastService;
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            //Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);
            
            //Act
            teamService.AddTeamMember("George");

            //Assert
            Assert.Equal(6, teamService.GetTeamInfo().TeamMembers.Count);
            broadcastServiceMock.Verify(_ => _.NewTeamMemberAdded(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
        }

        //[Fact]
        //public void DeleteTeamMemberFromTheTeam()
        //{
        //    //Assume
        //    ITeamService teamService = new TeamService();
        //    var targetTeamMember = teamService.GetTeamInfo().TeamMembers[1];
        //    int targetId = targetTeamMember.Id;
        //    //Act
        //    teamService.DeleteTeamMember(targetId);
        //    //Assert
        //    Assert.Equal(4, teamService.GetTeamInfo().TeamMembers.Count);

        //}


        //[Fact]
        //public void EditTeamMemberInTheTeam()
        //{
        //    //Assume
        //    ITeamService teamService = new TeamService();
        //    //Act
        //    teamService.EditTeamMember(3,"NewName");
        //    //Assert
        //    Assert.Equal("NewName", teamService.GetTeamMemberById(3).Name);


        //}


    }
}
