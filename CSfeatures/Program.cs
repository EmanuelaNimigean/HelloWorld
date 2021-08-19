using System;
using System.IO;
using System.Text.Json;

namespace CSfeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamMember teamMember = new TeamMember() { Name = "Member1" };
            string jsonString = JsonSerializer.Serialize(teamMember);
            Console.WriteLine(jsonString);
            File.WriteAllText("OutputFile.txt", jsonString);
            var readFromFile = File.ReadAllTextAsync("OutputFile.txt");
            readFromFile.Wait();
            var awaitOutput = readFromFile.Result;
            var teamMemberDeserialized = JsonSerializer.Deserialize<TeamMember>(awaitOutput);
            Console.WriteLine(teamMemberDeserialized);

            Console.Write("Choose coffee type:");
            var customerInput = Console.ReadLine();
            Func<string, string, string, string, Coffee> recipe = (customerInput=="FlatWhite")?FlatWhite:Espresso;
            Coffee coffee = MakeCoffee("grain", "sugar", "water", "milk", recipe);
            if (coffee != null)
            {
                Console.WriteLine($"Here is your coffee:{coffee}.");
            }
            else
            {
                Console.WriteLine("Null recipe.");
            }

        }

        static Coffee MakeCoffee(string coffeeGrains,string milk,string water,string sugar,Func<string,string,string,string,Coffee> recipe)
        {
            Coffee coffee = null;
            try
            {
                Console.WriteLine("Start preparing coffee.");
                coffee = recipe(coffeeGrains, milk, water, sugar);
            }
            catch(RecipeUnavailableException e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Something went wrong, no details.");
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
            return coffee;

        }

        static Coffee Espresso(string coffeeGrains, string milk, string water, string sugar)
        {
            throw new RecipeUnavailableException("out of stock");
        }

        static Coffee FlatWhite(string coffeeGrains, string milk, string water, string sugar)
        {
            return new Coffee("FlatWhite");
        }
    }
}
