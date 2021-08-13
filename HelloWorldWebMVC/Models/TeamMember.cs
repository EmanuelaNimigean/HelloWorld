using HelloWorldWebMVC.Services;
using System;

namespace HelloWorldWebMVC.Models
{
    public class TeamMember
    {
        private static int idCount = 0;
        private readonly ITimeService timeService;

        public TeamMember(string name, ITimeService timeService)
        {
            this.timeService = timeService;
            this.Id = idCount;
            this.Name = name;
            idCount++;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public int GetAge()
        {
            var age = this.timeService.GetNow().Subtract(this.Birthdate).Days;
            age = age / 365;
            return age;
        }
    }
}