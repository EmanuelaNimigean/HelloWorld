using System;

namespace HelloWorldWebMVC.Models
{
    public class TeamMember
    {
        private static int idCount = 0;

        public TeamMember(string name)
        {
            this.Id = idCount;
            this.Name = name;
            idCount++;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public int GetAge()
        {
            var age = DateTime.Now.Subtract(Birthdate).Days;
            age = age / 365;
            return age;
        }
    }
}