using HelloWorldWeb.Services;
using HelloWorldWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamMemberTests
    {
        [Fact]
        public void GettingAge()
        {
            //Assume
            ITeamService teamService = new TeamService();
            var newTeamMember = new TeamMember("Emma");
            newTeamMember.Birthdate = new DateTime(1998, 4, 22);

            //Act
            int age = newTeamMember.GetAge();

            //Assert
            Assert.Equal(23, age);

        }

    }
}
