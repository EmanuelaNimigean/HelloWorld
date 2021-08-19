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
            var readFromFile = File.ReadAllTextAsync("OutputFile.txt");
            readFromFile.Wait();
            var awaitOutput = readFromFile.Result;
            var teamMemberDeserialized = JsonSerializer.Deserialize<TeamMember>(awaitOutput);
            Console.WriteLine(teamMemberDeserialized);
        }
    }
}
