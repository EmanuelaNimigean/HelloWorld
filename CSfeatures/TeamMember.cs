using System;
using System.Diagnostics;

namespace CSfeatures
{
    [DebuggerDisplay("{Name}[{Id}]")]
    public class TeamMember
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }
    }
}