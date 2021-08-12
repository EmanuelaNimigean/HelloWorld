using HelloWorldWebMVC.Services;
using HelloWorldWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace HelloWorldWeb.Test
{
    public class TeamMemberTests
    {
        private Mock<ITimeService> timeMock;

        private void InitializeTimeServiceMock()
        {
            timeMock = new Mock<ITimeService>();
            timeMock.Setup(_ => _.GetNow()).Returns(new DateTime(2021, 8, 11));
            
        }

        [Fact]
        public void GettingAge()
        {
            //Assume
            InitializeTimeServiceMock();
            var timeService = timeMock.Object;
            var newTeamMember = new TeamMember("Emma", timeService);
            newTeamMember.Birthdate = new DateTime(1998, 4, 22);

            //Act
            int age = newTeamMember.GetAge();

            //Assert
            timeMock.Verify(_=>_.GetNow(), Times.AtMostOnce());
            Assert.Equal(23, age);

        }

    }

    /*internal class FakeTimeService : ITimeService
    {
        public DateTime GetNow()
        {
            return new DateTime(2021, 08, 11);
        }
    }*/
}
