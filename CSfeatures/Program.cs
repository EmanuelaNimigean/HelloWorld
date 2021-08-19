using System;
using System.IO;
using System.Text.Json;

namespace CSfeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamMember teamMember = new TeamMember() { Name="Member1"};
            string jsonString = JsonSerializer.Serialize(teamMember);
            Console.WriteLine(jsonString);
            File.WriteAllText("OutputFile.txt", jsonString);
            teamMember = JsonSerializer.Deserialize<TeamMember>(jsonString);
        }
    }
}
