// See https://aka.ms/new-console-template for more information

using NhlSystemClassLibrary;
using System.Diagnostics;

// Prompt and read in the team name
//Console.Write("Enter the team name: ");
//string teamName = Console.ReadLine();

string[] games = new string[12] { "Mario", "Mario Galaxy", "Shovel Knight", "Soul Knight", "Mario Kart", "Portal", "Minecraft", "Terraria", "9", "10", "11", "12" };


//TODO 2       Print the names of each game title using a foreach loop

foreach(string currentGame in games)
{
    Debug.WriteLine (currentGame);
}

//TODO 3       Print the names using a for loop
for (int i = 0; i < games.Length; i++)
{
    Debug.WriteLine(games[i]);
}
//TODO 4       Print the name of each title using the  Lin() Enumerable  ForEach method
games.ToList().ForEach(currentGameTitle => Console.WriteLine (currentGameTitle));


// Sort the titles ascending
games
    .OrderBy(currentGameTitle => currentGameTitle)
    .ToList()
    .ForEach(gameTitle => Console.WriteLine (gameTitle));


// ONly return Titles with the word SUPER      using WHERE
games.Where(currentGameTitle => currentGameTitle.Contains("Super"))
    .ToList()
    .ForEach (gameTitle => Console.WriteLine (gameTitle));


// using ANY   return if there are titles with the name Mario
bool anyMarioTitle = games.Any(currentGameTitle => currentGameTitle.Contains("Mario"));
if (anyMarioTitle)
{
    Console.WriteLine("YES THERE IS MARIO");
} else
{  
    Console.WriteLine("NO MARIO");
}






try
{
    // Create a new Team instance
    Team oilers = new Team("Oilers","Edmonton","Rogers Place", Conference.Western, Division.Pacific);
    // Print the Team Name
    //Console.WriteLine($"Team Name: {currentTeam.Name}");
    Console.WriteLine(oilers);
    //Console.WriteLine($"Name: {oilers.Name}, City: {oilers.City}, Arena: {oilers.Arena}");
}
catch(ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);  
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch
{
    Console.WriteLine("Incorrect exception thrown");
}

