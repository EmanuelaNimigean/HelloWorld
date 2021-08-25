using HelloWorldWeb.Services;
using HelloWorldWebMVC;
using HelloWorldWebMVC.Services;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamServiceTest
    {
        private Mock<IHubContext<MessageHub>> messageHubMock = null;

        //[Fact]
        //public void AddTeamMemberToTheTeam()
        //{
        //    //Assume
        //    ITeamService teamService = new TeamService();
        //    ITimeService timeService = new TimeService();
        //    //Act
        //    teamService.AddTeamMember("George");
        //    //Assert
        //    Assert.Equal(6, teamService.GetTeamInfo().TeamMembers.Count);

        //}

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

        [Fact]
        public void Check()
        {
            //Assume
            InitializeMessageHubMock();
            hubAllClientsMock.Setup( _=>_.SendAsync("NewTeamMemberAdded", "Test", 22, It.IsAny<CancellationToken>()));
            var messageHub = messageHubMock.Object;
            //Act
            messageHub.Clients.All.SendAsync("NewTeamMemberAdded", "Test", 22);
            //Assert
            hubAllClientsMock.Verify(hubAllClients=> hubAllClients.SendAsync("NewTeamMemberAdded", "Test", 22, It.IsAny<CancellationToken>()),Times.Once());
            //Mock.Get(hubAllClientsMock).Verify(_ => _.SendAsync("NewTeamMemberAdded", "Test", 22), Times.Once());
        }

        private Mock<IHubClients> hubClientsMock;
        private Mock<IClientProxy> hubAllClientsMock;
        private void InitializeMessageHubMock()
        {
            // https://www.codeproject.com/Articles/1266538/Testing-SignalR-Hubs-in-ASP-NET-Core-2-1
            hubAllClientsMock = new Mock<IClientProxy>();
            hubClientsMock = new Mock<IHubClients>();
            hubClientsMock.Setup(_ => _.All).Returns(hubAllClientsMock.Object);
            messageHubMock = new Mock<IHubContext<MessageHub>>();
            messageHubMock.SetupGet(_ => _.Clients).Returns(hubClientsMock.Object);
        }

        private IHubContext<MessageHub> GetMockedMessageHub()
        {
            if (messageHubMock == null)
            {
                InitializeMessageHubMock();
            }
            return messageHubMock.Object;
        }
    }
}
