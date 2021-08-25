// <copyright file="TeamMemberTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HelloWorldWeb.Models;
    using HelloWorldWeb.Services;
    using Moq;
    using Xunit;

    public class TeamMemberTests
    {
        private Mock<ITimeService> timeMock;

        private void InitializeTimeServiceMock()
        {
            this.timeMock = new Mock<ITimeService>();
            this.timeMock.Setup(_ => _.Now()).Returns(new DateTime(2021, 08, 11));
        }

        [Fact]
        public void TestGetAgeEqual()
        {
            // Assume
            this.InitializeTimeServiceMock();
            var timeService = this.timeMock.Object;
            TeamMember teamMember = new TeamMember("Ioan", timeService);
            teamMember.BirthDate = new DateTime(2000, 01, 01);
            int expectedAge = 21;

            // Act
            int computedAge = teamMember.GetAge();

            // Assert
            Assert.Equal(expectedAge, computedAge);
            this.timeMock.Verify(_ => _.Now(), Times.Once());
        }
    }
}
